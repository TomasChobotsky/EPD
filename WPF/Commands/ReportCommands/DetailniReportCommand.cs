using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Data;
using WPF.Services;

namespace WPF.Commands.ReportCommands
{
    public class DetailniReportCommand : CommandBase
    {
        private List<Customer> _customers;
        private List<Project> _projects;
        private List<Activity> _activities;
        public DetailniReportCommand(ApiRepository apiRepository)
        {
            FillCollections(apiRepository);
        }
        
        public override void Execute(object parameter)
        {
            try
            {
                using StreamWriter writer = new StreamWriter("DetailniReport.html");
                foreach (var customer in _customers)
                {
                    TimeSpan totalHours = new TimeSpan();
                    double totalWage = 0;
                    writer.WriteLine($"<h1>{customer.Name}</h1>");
                    foreach (var project in _projects.Where(t => t.CustomerId == customer.Id))
                    {
                        writer.WriteLine($"<h2 style=\"margin-left: 15px\">{project.Title}</h2>");
                        writer.WriteLine("<table style=\"border:1px solid black; margin-left: 30px\">");
                        writer.WriteLine("<tr style=\"border:1px solid black;\">");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Začátek</th>");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Konec</th>");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Činnost</th>");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Doba</th>");
                        writer.WriteLine("<th style=\"border:1px solid black;\">Cena</th>");
                        writer.WriteLine("</tr>");
                        foreach (var activity in _activities.Where(t => t.ProjectId == project.Id))
                        {
                            double wage = Math.Ceiling(project.Wage * (activity.End - activity.Start).TotalHours);
                            TimeSpan hours = activity.End - activity.Start;
                            writer.WriteLine("<tr style=\"border:1px solid black;\">");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{activity.Start}</th>");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{activity.End}</th>");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{activity.Description}</th>");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{hours}</th>");
                            writer.WriteLine($"<th style=\"border:1px solid black;\">{wage} Kč</th>");
                            writer.WriteLine("</tr>");
                            totalHours += hours;
                            totalWage += wage;
                        }
                        writer.WriteLine("</table>");
                    }
                    writer.WriteLine($"<h3 style=\"margin-left: 15px\">Celková činnost: {totalHours}</h3>");
                    writer.WriteLine($"<h3 style=\"margin-left: 15px\">Celková mzda: {totalWage} Kč</h3>");
                }
                MessageBox.Show("Detailni report byl uspesne vygenerovan!");
            }
            catch
            {
                MessageBox.Show("Detailni report nemohl byt vygenerovan!");
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