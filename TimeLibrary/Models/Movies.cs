﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLibrary.Models
{
    public partial class Movies
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Title { get; set; }
        public string[] ItemArray => new[]
        {
            Title,
            Duration.Value.Hours.ToString(),
            Duration.Value.Minutes.ToString()
        };

        public override string ToString()
        {
            return $"{Title} runs {Duration.Value.Hours} hours {Duration.Value.Minutes}";
        }
    }
}