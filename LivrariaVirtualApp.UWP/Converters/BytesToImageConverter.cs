using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace LivrariaVirtualApp.UWP.Converters
{
    /// <summary>
    /// Helper to manage images to bytes and back
    /// </summary>
    public class BytesToImageConverter : IValueConverter
    {
        public static async Task<BitmapImage> GetBitmapAsync(byte[] data)
        {
            var bitmapImage = new BitmapImage();

            using (var stream = new InMemoryRandomAccessStream())
            {
                using (var writer = new DataWriter(stream))
                {
                    writer.WriteBytes(data);
                    await writer.StoreAsync();
                    await writer.FlushAsync();
                    writer.DetachStream();
                }

                stream.Seek(0);
                await bitmapImage.SetSourceAsync(stream);
            }

            return bitmapImage;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(value is byte[]))
                return null;

            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])value);
                    writer.StoreAsync().GetResults();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                return image;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(value is BitmapImage))
                return (null);
            return (null);
        }
    }
}