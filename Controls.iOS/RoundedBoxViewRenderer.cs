using Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(Controls.iOS.RoundedBoxViewRenderer))]
namespace Controls.iOS
{
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null) return;
            Layer.MasksToBounds = true;
            UpdateCornerRadius(Element as RoundedBoxView);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName
                || e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName
                || e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
            {
                UpdateCornerRadius(Element as RoundedBoxView);
            }
        }

        private void UpdateCornerRadius(RoundedBoxView box)
        {
            Layer.CornerRadius = (float)box.CornerRadius;
            Layer.BorderColor = box.Stroke.ToCGColor();
            Layer.BorderWidth = (float)box.StrokeThickness;
        }
    }

}
