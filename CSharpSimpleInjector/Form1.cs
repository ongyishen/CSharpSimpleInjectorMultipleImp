using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CSharpSimpleInjector
{
    public partial class Form1 : Form
    {
        private const string MyDogName = "MyDog";
        private const string MyCatName = "MyCat";

        Container container { get; set; }

        public Type[] ImplementTypes
        {
            get
            {


                List<Type> data = AnimalMapImplementation.Select(d => d.Value).ToList();



                return data.ToArray();
            }
        }

        public Dictionary<string, Type> AnimalMapImplementation
        {
            get
            {
                Dictionary<string, Type> dict = new Dictionary<string, Type>();
                dict.Add(MyDogName, typeof(Dog));
                dict.Add(MyCatName, typeof(Cat));
                return dict;
            }
        }

        public void DependencyRegistration()
        {
            container = new SimpleInjector.Container();
            container.Collection.Register<IAnimal>(ImplementTypes);
            container.Verify();
        }

        public T Resolve<T>(string animalName) where T : class
        {
            try
            {
                if (AnimalMapImplementation.ContainsKey(animalName))
                {
                    var implementType = AnimalMapImplementation[animalName];

                    var myPet = container.GetAllInstances<T>().Where(x => x.GetType().Name == implementType.Name).FirstOrDefault();

                    return myPet;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            MessageBox.Show($"Failed To Resolve {animalName}");

            return null;

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void btnDog_Click(object sender, EventArgs e)
        {
            var myPet = Resolve<IAnimal>(MyDogName);
            if (myPet != null)
            {
                myPet.MakeSound();
            }

        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            var myPet = Resolve<IAnimal>(MyCatName);
            if (myPet != null)
            {
                myPet.MakeSound();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DependencyRegistration();
        }
    }
}
