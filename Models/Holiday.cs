using System;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media.Animation;
using CursovaRobota.Models;
using CursovaRobota.Services;
using CursovaRobota.Views;

namespace CursovaRobota.Models
{
    public class Holiday : CalendarItem
    {
        // CalendarItem уже має Id, Start, End → тут не потрібні
        public string Title { get; set; }
        public string Description { get; set; }
        public string AnimationKey { get; set; }


        /// <summary>Свято відбувається щороку в цю ж дату.</summary>
        public int Month => Start.Month;
        public int Day => Start.Day;

        public override string DisplayName => Title;

        public override void Trigger()
        {
            Helpers.AnimationManager.Play(AnimationKey);
        }

    }
}
