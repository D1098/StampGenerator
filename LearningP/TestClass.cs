using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.DrawingCore;
using System.DrawingCore.Drawing2D;

using System.Text.Json;

namespace LearningP
{
    /// <summary>
    /// Класс для тестов
    /// </summary>
    public class TestClass
    {
        public int Id { get; set; }// = Guid.NewGuid();
        public Guid StampGuid { get; set; }
        public string Reason { get; set; }
    }
}
