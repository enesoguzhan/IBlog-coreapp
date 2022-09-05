namespace IBlog.UI.Helpers
{
    public static class ImagesUploader
    {
        public static string UploadImage(IFormFile image)
        {
            string[] extensions = { ".jpg", ".jpeg" };
            if (image != null)
            {
                string extension = Path.GetExtension(image.FileName);                
                if (extensions.Contains(extension))
                {
                    string name = Guid.NewGuid() + extension;
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/" + name);
                    using (FileStream stream = new FileStream(savePath, FileMode.Create))
                    {
                        
                        image.CopyTo(stream);
                    }
                    return name;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "1";
            }
        }
        public static void DeleteImage(string name)
        {
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/" + name));
        }
    }

}
