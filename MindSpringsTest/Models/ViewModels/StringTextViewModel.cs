namespace MindSpringsTest.Models.ViewModels
{
    public class StringTextGetViewModel
    {
        public int TextId { get; set; }
        public string TextToTranslate { get; set; }
    }
    public class StringTextCreateViewModel
    {
        public int TextId { get; set; }
        public string TextToTranslate { get; set; }
    }

    public class TranslatorResponseViewModel
    {
        public string Translation { get; set; }

    }
}
