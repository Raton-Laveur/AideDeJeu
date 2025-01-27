﻿using AideDeJeu.ViewModels;
using AideDeJeu.ViewModels.Library;
using AideDeJeuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AideDeJeu.Views.Library
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookmarksPage : ContentPage
	{
		public BookmarksPage ()
		{
			InitializeComponent ();

            BindingContext = DependencyService.Get<BookmarksViewModel>();
		}
    }
}