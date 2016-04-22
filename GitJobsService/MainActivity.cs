using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GitJobsService.Core.Service;
using GitJobsService.Core.Model;
using System.Collections.Generic;

namespace GitJobsService
{
    [Activity(Label = "GitJobsService", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ResponseListener // : significa herança. O Main Activity é um ResponseListener
    {
        public void OnResult(List<Position> positions)// tem que ter esse metodo onresult para ele saber 
        {
            foreach(Position p in positions)
            { // bloco que cada objeto Position, recebe p.title
                Console.Out.WriteLine(p.title);
				var x = new TextView (this);
				x.Text = p.title;
				SetContentView (x);

            }
        }

        protected override void OnCreate(Bundle bundle)
        { //so pode ser chamado nessa classe Requisicao assincrona, faz a busca paralelo enquanto os ostros processos da aplicacao tao rodando
            base.OnCreate(bundle); //DO android, toda classe tem que ter esse metodo onCreate, senao nao vai rodar atividade. Toda atividade nova tem que chamar esse metodo. 
            SetContentView(Resource.Layout.Main);

            Position.Find(this) //esta referenciando a propria classe. Ele recebe que criou a trad, no caso  é a MainActivity 
                .Description("java")
                .FullTime(true).Execute();
        }
    }
}