using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    public class AlbumModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            int id = Convert.ToInt32(request.Form["AlbumId"]);
            int genreId;
            Int32.TryParse(request.Form["GenreId"], out genreId);
            int artistId;
            Int32.TryParse(request.Form["ArtistId"], out artistId);
            decimal price = Decimal.Parse(request.Form["Price"]);

            ModelBindingContext newBindingContext = new ModelBindingContext
            {
                ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(
                    () => new Album
                    {
                        AlbumId = id,
                        GenreId = genreId,
                        ArtistId = artistId,
                        Title = request.Form["Title"],
                        Price = price,
                        AlbumArtUrl = request.Form["AlbumArtUrl"]
                    },
                    typeof(Album)
                    ),
                ModelState = bindingContext.ModelState,
                ValueProvider = bindingContext.ValueProvider
            };
            // The following call validates the ModelState in the newBindingContext against values in the controllerContext.
            return base.BindModel(controllerContext, newBindingContext);
        }

        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.ComponentType == typeof(Album))
            {
                if (propertyDescriptor.Name == "AlbumId")
                {
                    var obj = bindingContext.ValueProvider.GetValue("AlbumId");
                    return Convert.ToInt32(obj.AttemptedValue);
                }
            }

            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
}