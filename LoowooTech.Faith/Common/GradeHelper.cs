using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace LoowooTech.Faith.Common
{
    public static class GradeHelper
    {
        private static XmlDocument _configXml { get; set; }
        static GradeHelper()
        {
            _configXml = new XmlDocument();
            _configXml.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, System.Configuration.ConfigurationManager.AppSettings["Grade"]));
        }

        private static Grade Analyze(XmlNode node)
        {
            var name = node.Attributes["name"].Value;
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            int a = 0;
            double b = .0;
            var model = new Grade
            {
                Name = name,
                Title = node.Attributes["Title"].Value,
                Description = node.Attributes["Description"].Value,
                Order = int.TryParse(node.Attributes["Order"].Value, out a) ? a : 0
            };
            if(double.TryParse(node.Attributes["MinScore"].Value,out b))
            {
                model.MinScore = b;
            }
            if(double.TryParse(node.Attributes["MaxScore"].Value,out b))
            {
                model.MaxScore = b;
            }
            if(int.TryParse(node.Attributes["Bad"].Value,out a))
            {
                model.Bad = a;
            }
            if(int.TryParse(node.Attributes["Less"].Value,out a))
            {
                model.Less = a;
            }
            if(int.TryParse(node.Attributes["Litter"].Value,out a))
            {
                model.Litter = a;
            }
            return model;
        }
        public static List<Grade> GetList()
        {
            var list = new List<Grade>();
            var nodes = _configXml.SelectNodes("/Grades/Grade");
            if (nodes != null)
            {
                for(var i = 0; i < nodes.Count; i++)
                {
                    var node = nodes[i];
                    if (node == null)
                    {
                        continue;
                    }
                    var model = Analyze(node);
                    if (model != null)
                    {
                        list.Add(model);
                    }
                }
            }
            return list;
        }

    }
}