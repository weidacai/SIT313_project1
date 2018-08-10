using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Java.Util;
using Android.Graphics;
using Com.KD.Dynamic.Calendar.Generator;
using static Android.App.DatePickerDialog;

namespace Application
{
    [Activity(Label = "313",  Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class LoginActivity : AppCompatActivity, IOnDateSetListener
    {

        EditText mDateEditText;
        Calendar mCurrentDate;
        Bitmap mGeneratedDateIcon;
        ImageGenerator mGeneratorImage;
        ImageView mDisplayGeneratedImage;






        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginActivity);

            var btnGoBack = FindViewById<Button>(Resource.Id.btnGoBack);
            btnGoBack.Click += delegate {
                this.Finish();
            };

            mGeneratorImage = new ImageGenerator(this);
            mDateEditText = FindViewById<EditText>(Resource.Id.txtDateEntered);
            mDisplayGeneratedImage = FindViewById<ImageView>(Resource.Id.imageGen);

            mGeneratorImage.SetIconSize(50, 50);
            mGeneratorImage.SetDateSize(30);
            mGeneratorImage.SetMonthSize(10);
            mGeneratorImage.SetDatePosition(42);
            mGeneratorImage.SetMonthPosition(14);
            mGeneratorImage.SetDateColor(Color.ParseColor("#3c6eaf"));
            mGeneratorImage.SetMonthColor(Color.White);
            mGeneratorImage.SetStorageToSDCard(true);


            mDateEditText.Click += delegate {

                mCurrentDate = Calendar.Instance;
                int mYear = mCurrentDate.Get(CalendarField.Year);
                int mMonth = mCurrentDate.Get(CalendarField.Month);
                int mDay = mCurrentDate.Get(CalendarField.DayOfMonth);

                DatePickerDialog mDate = new DatePickerDialog(this, this, mYear, mMonth, mDay);
                mDate.Show();

            };

        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            mDateEditText.Text = $" {dayOfMonth}-{month + 1}-{year}";
            mCurrentDate.Set(year, month, dayOfMonth);
            mGeneratedDateIcon = mGeneratorImage.GenerateDateImage(mCurrentDate, Resource.Drawable.empty_calendar);
            mDisplayGeneratedImage.SetImageBitmap(mGeneratedDateIcon);
        }
    }
}

