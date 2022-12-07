using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using AutoMapper;
using Data;
using WPF.Models;
using WPF.Services;

namespace WPF.Commands.ReportCommands
{
    public class SouhrnyReportCommand : CommandBase
    {
        private List<Customer> _customers;
        private List<Project> _projects;
        private List<Activity> _activities;
        public SouhrnyReportCommand(ApiRepository apiRepository)
        {
            FillCollections(apiRepository);
        }
        
        public override void Execute(object parameter)
        {
            try
            {
                using StreamWriter writer = new StreamWriter("SouhrnyReport.html");
                foreach (var customer in _customers)
                {
                    TimeSpan totalHours = new TimeSpan();
                    double totalWage = 0;
                    writer.WriteLine($"<h1>{customer.Name}</h1>");
                    foreach (var project in _projects.Where(t => t.CustomerId == customer.Id))
                    {
                        TimeSpan totalProjectHours = new TimeSpan();
                        double totalProjectWage = 0;
                        writer.WriteLine($"<h2 style=\"margin-left: 15px\">{project.Title}</h2>");
                        writer.WriteLine("<table style=\"border:1px solid black; margin-left: 30px\">");
                        writer.WriteLine("<tr style=\"border:1px solid black;\">");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Činnost</th>");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Doba</th>");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Cena</th>");
                        writer.WriteLine("</tr>");
                        
                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Activity, ActivityDTO>());
                        var mapper = config.CreateMapper();
                        

                        List<ActivityDTO> dto = mapper.Map<List<ActivityDTO>>(_activities);
                        foreach (var activityDto in dto)
                        {
                            activityDto.Hours = activityDto.End - activityDto.Start;
                        }
                        dto = dto.GroupBy(x => x.Description).Select(x => new ActivityDTO { Id = x.First().Id, Description = x.Key, 
                                Start = x.First().Start, End = x.First().End, ProjectId = x.First().ProjectId, UserId = x.First().UserId, 
                                Hours = new TimeSpan(x.Sum(y => y.Hours.Ticks)) })
                            .ToList();

                        foreach (var activity in dto.Where(t => t.ProjectId == project.Id))
                        {
                            TimeSpan hours = activity.Hours;

                            double wage = Math.Ceiling(project.Wage * hours.TotalHours);
                            writer.WriteLine("<tr style=\"border:1px solid black;\">");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{activity.Description}</th>");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{hours}</th>");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{wage} Kč</th>");
                            writer.WriteLine("</tr>");
                            totalHours += hours;
                            totalWage += wage;
                            totalProjectHours += hours;
                            totalProjectWage += wage;
                        }
                        
                        writer.WriteLine("<tr style=\"border:1px solid black;\">");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Celkem</th>");
                        writer.WriteLine($"<th style=\"border:1px solid black;\">{totalProjectHours}</th>");
                        writer.WriteLine($"<th style=\"border:1px solid black;\">{totalProjectWage} Kč</th>");
                        writer.WriteLine("</tr>");
                        writer.WriteLine("</table>");
                    }
                    writer.WriteLine($"<h3 style=\"margin-left: 15px\">Celková činnost: {totalHours}</h3>");
                    writer.WriteLine($"<h3 style=\"margin-left: 15px\">Celková mzda: {totalWage} Kč</h3>");
                }
                MessageBox.Show("Souhrny report byl uspesne vygenerovan!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void FillCollections(ApiRepository apiRepository)
        {
            _customers = new List<Customer>(await apiRepository.Get<Customer>("api/customers"));
            _projects = new List<Project>(await apiRepository.Get<Project>("api/projects"));
            _activities = new List<Activity>(await apiRepository.Get<Activity>("api/activities"));
        }
    }
}