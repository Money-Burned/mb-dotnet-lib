﻿using System.Collections.ObjectModel;
using MoneyBurned.Dotnet.Lib.Data;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MoneyBurned.Dotnet.Lib
{
    public class Job
    {
        private readonly List<Resource> resources = [];
        public ReadOnlyCollection<Resource> Resources { get { return new ReadOnlyCollection<Resource>(resources); }}
        public string Name { get; set; } = "New Job";
        public Guid Id { get; } = Guid.NewGuid();
        public TimeSpan ElapsedTime { get { return CalculateElapsedTime(); } }
        public Decimal ElapsedCost { get { return CalculateCosts(); } }
        public DateTime StartTime { get; private set; } = DateTime.MinValue;
        public DateTime EndTime { get; private set; } = DateTime.MaxValue;


        public Job()
        {

        }

        public Job(string name)
        {
            this.Name = name;
        }
        
        public Job(Resource[] resources)
        {
            this.resources.AddRange(resources);
        }

        public Job(string name, Resource[] resources)
        {
            this.Name = name;
            this.resources.AddRange(resources);
        }

        public void StartRecording()
        {
            StartTime = DateTime.Now;
        }

        public void EndRecording()
        {
            EndTime = DateTime.Now;
        }

        public void AddResource(Resource resource)
        {
            this.resources.Add(resource);
        }

        public void AddResources(Resource[] resources)
        {
            this.resources.AddRange(resources);
        }

        public void RemoveResource(Resource resource)
        {
            this.resources.Remove(resource);
        }

        private Decimal CalculateCosts()
        {
            Decimal costs = 0;
            foreach (Resource resource in resources)
            {
                costs += resource.CostPerWorkHour * Convert.ToDecimal(ElapsedTime.TotalHours);
            }
            return costs;
        }

        private TimeSpan CalculateElapsedTime()
        {
            TimeSpan elapsedTime = TimeSpan.Zero;
            if (StartTime != DateTime.MinValue)
            {
                DateTime now = EndTime != DateTime.MaxValue ? EndTime : DateTime.Now;
                elapsedTime = now - StartTime;
            }
            return elapsedTime;
        }

        public override string ToString()
        {
            if (StartTime != DateTime.MinValue)
            {
                string status = EndTime != DateTime.MaxValue ? "ended" : "running";
                return string.Format("Job {3} with {0} resource(s) took {1:c} and a total cost of {2:C2}.", resources.Count, ElapsedTime, CalculateCosts(), status);
            }
            else
            {
                return string.Format("Job with {0} resource(s) wasn't started yet.", resources.Count);
            }
        }
    }
}
