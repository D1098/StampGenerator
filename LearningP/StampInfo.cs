using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.DrawingCore;
using System.DrawingCore.Drawing2D;

using System.Text.Json;

namespace LearningP
{
    /// <summary>
    /// Класс, содержащий изображение штампа и информацию о нем
    /// </summary>
    public class StampInfo
    {
        // Guid OwnerGuid {} ???

        [Key]
        public Guid Key { get; set; } = Guid.NewGuid();
        public Guid StampGuid { get; set; }
        public string Reason { get; set; }
        public DateTime Time { get; set; }
        //[NotMapped]
        //public Image Stamp { get; set; }
        public byte[] Stamp { get; set; }

        public StampInfo() { }

        // Конструктор
        public StampInfo(string fio) 
        { 
            Reason = "Testing";
            Stamp = ImageToBytes(ImageFromTextAnyLength(fio)); 
            Time = DateTime.Now;
            StampGuid = Guid.NewGuid();
        }

        // Конвертация изображения в массив байтов
        byte[] ImageToBytes(Image img) => (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));

        // Убрать
        public string JsonSer()
        {
            return JsonSerializer.Serialize(this);
        }

        // Для тестов
        public override string ToString()
        {
            return $"\"Guid\":{StampGuid},\"Reason\":{Reason},\"Time\":{Time},\"Stamp\":{Stamp}";
        }

        // Генератор изображений штампов
        Image ImageFromTextAnyLength(string text)
        {
            Font font = new Font(FontFamily.Families[0], 12);
            Brush foreGround = Brushes.BlueViolet;
            string day = DateTime.Now.ToString(), staticText = "ПОДПИСАНО ПРОСТОЙ ЭЛЕКТРОННОЙ ПОДПИСЬЮ\nВ СООТВЕТСТВИИ С СОГЛАШЕНИЕМ\nОБ ЭЛЕКТРОННОМ ВЗАИМОДЕЙСТВИИ";
            // Стандартный размер холста
            var img = new Bitmap(480, 160);
            Graphics sizeTest = Graphics.FromImage(img);
            SizeF e = sizeTest.MeasureString(text, font);
            // Если строка с ФИО слишком длинная, меняем размер холста
            if (e.Width > 279)
            {
                img = new Bitmap(480 + (int)e.Width - 279 + 20, 160);
            }
            using (var grp = Graphics.FromImage(img))
            {
                grp.SmoothingMode = SmoothingMode.AntiAlias;
                grp.Clear(Color.White);
                grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // TODO: Возможно для ФИО и даты лучше сделать свой формат с выравниванием по краям + разобраться с длиной строки с ФИО
                // Формат текста
                StringFormat sf = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.NoClip);
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                // Формат даты
                StringFormat sfDate = new StringFormat();
                sfDate.LineAlignment = StringAlignment.Center;
                sfDate.Alignment = StringAlignment.Near;
                // Шрифт для статики
                Font f12 = new Font(FontFamily.Families[0], 10);
                // Рисуем три строки
                grp.DrawString(staticText, f12, foreGround, new RectangleF(0, -20, img.Width, 160), sf);
                grp.DrawString(day, font, foreGround, new RectangleF(30, 50, img.Width, 160), sfDate);
                grp.DrawString(text, font, foreGround, new RectangleF(100, 52, img.Width, 160), sf);
                //Console.WriteLine((float)img.Width / 480 + "; " + e.ToString());
                // Рисуем прямоугольник
                grp.DrawRectangle(new Pen(Color.BlueViolet, 5), new Rectangle(0, 0, img.Width, 160));
            }
            return img;
        }
    }
}
