﻿using System.Text.RegularExpressions;

namespace HostsBlockUpdater
{
    public sealed class HostFileLine
    {
        public HostFileLine()
        {
        }

        public HostFileLine(string line)
        {
            this.IsComment = line.Trim().StartsWith("#");

            var cleanedLine = line.TrimStart(new char[] { '#' });
            var splitted = cleanedLine.Split(' ');

            if (splitted.Length > 1)
            {
                var ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                var result = ip.Matches(splitted[0].Trim());

                this.IP = result.Count > 0 ? result[0].ToString() : "";
                this.HostName = splitted[1].Trim();
            }
        }

        public string HostName { get; set; } = "";
        public string IP { get; set; } = "";
        public bool IsComment { get; set; }

        public override string ToString()
        {
            if (this.IsComment)
                return "#";

            return $"{this.IP} {this.HostName}";
        }
    }
}