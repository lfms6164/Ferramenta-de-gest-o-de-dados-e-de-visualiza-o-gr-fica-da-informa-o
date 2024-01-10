using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        XmlSerializer xs;
        List<Alunos> ls;
        string dT;
        string cT;      

                 //keys, values
        Dictionary<int, string> distritos = new Dictionary<int, string>()
            {
                {1, "Açores"},
                {2, "Aveiro"},
                {3, "Beja"},
                {4, "Braga"},
                {5, "Bragança"},
                {6, "Castelo Branco"},
                {7, "Coimbra"},
                {8, "Évora"},
                {9, "Faro"},
                {10, "Guarda"},
                {11, "Leiria"},
                {12, "Lisboa"},
                {13, "Madeira"},
                {14, "Portalegre"},
                {15, "Porto"},
                {16, "Santarém"},
                {17, "Setúbal"},
                {18, "Viana do Castelo"},
                {19, "Vila Real"},
                {20, "Viseu"}
        };

        Dictionary<int, string> cAcores = new Dictionary<int, string>
            {
                {1, "Angra do Heroísmo"},
                {2, "Calheta"},
                {3, "Corvo"},
                {4, "Horta"},
                {5, "Lagoa"},
                {6, "Lajes das Flores"},
                {7, "Lajes do Pico"},
                {8, "Madalena"},
                {9, "Nordeste"},
                {10, "Ponta Delgada"},
                {11, "Povoação"},
                {12, "Ribeira Grande"},
                {13, "S. Roque do Pico"},
                {14, "Santa Cruz da Graciosa"},
                {15, "Santa Cruz das Flores"},
                {16, "Velas"},
                {17, "Vila do Porto"},
                {18, "Vila Franca do Campo"},
                {19, "Vila Praia da Vitória"}
            };

        Dictionary<int, string> cAveiro = new Dictionary<int, string>
            {
                {1, "Águeda"},
                {2, "Albergaria-a-Velha"},
                {3, "Anadia"},
                {4, "Arouca"},
                {5, "Aveiro"},
                {6, "Castelo de Paiva"},
                {7, "Espinho"},
                {8, "Estarreja"},
                {9, "ílhavo"},
                {10, "Mealhada"},
                {11, "Murtosa"},
                {12, "Oliveira de Azeméis"},
                {13, "Oliveira do Bairro"},
                {14, "Ovar"},
                {15, "S. João da Madeira"},
                {16, "Santa Maria da Feira"},
                {17, "Sever do Vouga"},
                {18, "Vagos"},
                {19, "Vale de Cambra"}
            };

        Dictionary<int, string> cBeja = new Dictionary<int, string>
            {
                {1, "Aljustrel"},
                {2, "Almodôvar"},
                {3, "Alvito"},
                {4, "Barrancos"},
                {5, "Beja"},
                {6, "Castro Verde"},
                {7, "Cuba"},
                {8, "Ferreira do Alentejo"},
                {9, "Mértola"},
                {10, "Moura"},
                {11, "Odemira"},
                {12, "Ourique"},
                {13, "Serpa"},
                {14, "Vidigueira"}
            };

        Dictionary<int, string> cBraga = new Dictionary<int, string>
            {
                {1, "Amares"},
                {2, "Barcelos"},
                {3, "Braga"},
                {4, "Cabeceiras de Basto"},
                {5, "Esposende"},
                {6, "Fafe"},
                {7, "Guimarães"},
                {8, "Póvoa de Lanhoso"},
                {9, "Terras de Bouro"},
                {10, "Vieira do Minho"},
                {11, "Vila Nova de Famalicão"},
                {12, "Vila Verde"},
                {13, "Vizela"}
            };

        Dictionary<int, string> cBraganca = new Dictionary<int, string>
            {
                {1, "Alfândega da Fé"},
                {2, "Bragança"},
                {3, "Carrazeda de Ansiães"},
                {4, "Freixo de Espada à Cinta"},
                {5, "Macedo de Cavaleiros"},
                {6, "Miranda do Douro"},
                {7, "Mirandela"},
                {8, "Mogadouro"},
                {9, "Torre de Moncorvo"},
                {10, "Vila Flor"},
                {11, "Vimioso"},
                {12, "Vinhais"}
            };

        Dictionary<int, string> cCasteloBranco = new Dictionary<int, string>
            {
                {1, "Belmonte"},
                {2, "Castelo Branco"},
                {3, "Covilhã"},
                {4, "Fundão"},
                {5, "Idanha-a-Nova"},
                {6, "Oleiros"},
                {7, "Penamacor"},
                {8, "Proença-a-Nova"},
                {9, "Sertã"},
                {10, "Vila de Rei"},
                {11, "Vila Velha de Ródão"}
            };

        Dictionary<int, string> cCoimbra = new Dictionary<int, string>
            {
                {1, "Arganil"},
                {2, "Cantanhede"},
                {3, "Coimbra"},
                {4, "Condeixa-a-Nova"},
                {5, "Figueira da Foz"},
                {6, "Góis"},
                {7, "Lousã"},
                {8, "Mira"},
                {9, "Miranda do Corvo"},
                {10, "Montemor-o-Velho"},
                {11, "Olveira do Hospital"},
                {12, "Pampilhosa da Serra"},
                {13, "Penacova"},
                {14, "Penela"},
                {15, "Soure"},
                {16, "Tábua"},
                {17, "Vila Nova de Poiares"}
            };

        Dictionary<int, string> cEvora = new Dictionary<int, string>
            {
                {1, "Alandroal"},
                {2, "Arraiolos"},
                {3, "Borba"},
                {4, "Estremoz"},
                {5, "Évora"},
                {6, "Montemor-o-Novo"},
                {7, "Mora"},
                {8, "Mourão"},
                {9, "Portel"},
                {10, "Redondo"},
                {11, "Reguengos de Monsaraz"},
                {12, "Vendas Novas"},
                {13, "Viana do Alentejo"},
                {14, "Vila Viçosa"}
            };

        Dictionary<int, string> cFaro = new Dictionary<int, string>
            {
                {1, "Albufeira"},
                {2, "Alcoutim"},
                {3, "Aljezur"},
                {4, "Castro Marim"},
                {5, "Faro"},
                {6, "Lagoa"},
                {7, "Lagos"},
                {8, "Loulé"},
                {9, "Monchique"},
                {10, "Olhão"},
                {11, "Portimão"},
                {12, "São Brás de Alportel"},
                {13, "Silves"},
                {14, "Tavira"},
                {15, "Vila do Bispo"},
                {16, "Vila Real de Santo António"}
            };

        Dictionary<int, string> cGuarda = new Dictionary<int, string>
            {
                {1, "Aguiar da Beira"},
                {2, "Almeida"},
                {3, "Celorico da Beira"},
                {4, "Figueira de Castelo Rodrigo"},
                {5, "Fornos de Algodres"},
                {6, "Gouveia"},
                {7, "Guarda"},
                {8, "Manteigas"},
                {9, "Mêda"},
                {10, "Pinhel"},
                {11, "Sabugal"},
                {12, "Seia"},
                {13, "Trancoso"},
                {14, "Vila Nova de Foz Côa"}
            };

        Dictionary<int, string> cLeiria = new Dictionary<int, string>
            {
                {1, "Alcobaça"},
                {2, "Alvaiázare"},
                {3, "Anião"},
                {4, "Batalha"},
                {5, "Bombarral"},
                {6, "Caldas da Rainha"},
                {7, "Castanheira de Pêra"},
                {8, "Figueiró dos Vinhos"},
                {9, "Leiria"},
                {10, "Marinha Grande"},
                {11, "Nazaré"},
                {12, "Óbidos"},
                {13, "Pedrógão Grande"},
                {14, "Peniche"},
                {15, "Pombal"},
                {16, "Porto de Mós"}
            };

        Dictionary<int, string> cLisboa = new Dictionary<int, string>
            {
                {1, "Alenquer"},
                {2, "Amadora"},
                {3, "Arruda dos Vinhos"},
                {4, "Azambuja"},
                {5, "Cadaval"},
                {6, "Cascais"},
                {7, "Lisboa"},
                {8, "Loures"},
                {9, "Lourinhã"},
                {10, "Mafra"},
                {11, "Odivelas"},
                {12, "Oeiras"},
                {13, "Sintra"},
                {14, "Sobral de Monte Agraço"},
                {15, "Torres Vedras"},
                {16, "Vila Franca de Xira"}
            };

        Dictionary<int, string> cMadeira = new Dictionary<int, string>
            {
                {1, "Calheta"},
                {2, "Câmara de Lobos"},
                {3, "Funchal"},
                {4, "Machico"},
                {5, "Ponta de Sol"},
                {6, "Porto Moniz"},
                {7, "Porto Santo"},
                {8, "Ribeira Brava"},
                {9, "Santa Cruz"},
                {10, "Santana"},
                {11, "São Vicente"}
            };

        Dictionary<int, string> cPortalegre = new Dictionary<int, string>
            {
                {1, "Alter do Chão"},
                {2, "Arronches"},
                {3, "Avis"},
                {4, "Campo Maior"},
                {5, "Castelo de Vide"},
                {6, "Crato"},
                {7, "Elvas"},
                {8, "Fronteira"},
                {9, "Gavião"},
                {10, "Marvão"},
                {11, "Monforte"},
                {12, "Nisa"},
                {13, "Ponte de Sôr"},
                {14, "Portalegre"},
                {15, "Sousel"}
            };

        Dictionary<int, string> cPorto = new Dictionary<int, string>
            {
                {1, "Amarante"},
                {2, "Baião"},
                {3, "Felgueiras"},
                {4, "Gondomar"},
                {5, "Lousada"},
                {6, "Maia"},
                {7, "Marco de Canavesses"},
                {8, "Matosinhos"},
                {9, "Paços de Ferreira"},
                {10, "Paredes"},
                {11, "Penafiel"},
                {12, "Porto"},
                {13, "Póvoa de Varzim"},
                {14, "Santo Tirso"},
                {15, "Trofa"},
                {16, "Valongo"},
                {17, "Vila do Conde"},
                {18, "Vila Nova de Gaia"}
            };

        Dictionary<int, string> cSantarem = new Dictionary<int, string>
            {
                {1, "Abrantes"},
                {2, "Alcanena"},
                {3, "Almeirim"},
                {4, "Alpiarça"},
                {5, "Benavente"},
                {6, "Cartaxo"},
                {7, "Chamusca"},
                {8, "Constância"},
                {9, "Coruche"},
                {10, "Entroncamento"},
                {11, "Ferreia do Zêzere"},
                {12, "Golegã"},
                {13, "Mação"},
                {14, "Ourém"},
                {15, "Rio Maior"},
                {16, "Salvaterra de Magos"},
                {17, "Santarém"},
                {18, "Sardoal"},
                {19, "Tomar"},
                {20, "Torres Novas"},
                {21, "Vila Nova da Barquinha"}
            };

        Dictionary<int, string> cSetubal = new Dictionary<int, string>
            {
                {1, "Alcácer do Sal"},
                {2, "Alcochete"},
                {3, "Almada"},
                {4, "Barreiro"},
                {5, "Grândola"},
                {6, "Moita"},
                {7, "Montijo"},
                {8, "Palmela"},
                {9, "Santiago do Cacém"},
                {10, "Seixal"},
                {11, "Sesimbra"},
                {12, "Setúbal"},
                {13, "Sines"}
            };

        Dictionary<int, string> cVianadoCastelo = new Dictionary<int, string>
            {
                {1, "Arcos de Valvedez"},
                {2, "Caminha"},
                {3, "Melgaço"},
                {4, "Monção"},
                {5, "Paredes de Coura"},
                {6, "Ponte da Barca"},
                {7, "Ponte de Lima"},
                {8, "Valença"},
                {9, "Viana do Castelo"},
                {10, "Vila Nova de Cerveira"}
            };

        Dictionary<int, string> cVilaReal = new Dictionary<int, string>
            {
                {1, "Alijó"},
                {2, "Boticas"},
                {3, "Chaves"},
                {4, "Mesão Frio"},
                {5, "Mondim de Basto"},
                {6, "Montalegre"},
                {7, "Murça"},
                {8, "Peso da Régua"},
                {9, "Ribeira de Pena"},
                {10, "Sabrosa"},
                {11, "Santa Marta de Penaguião"},
                {12, "Valpaços"},
                {13, "Vila Pouca de Aguiar"},
                {14, "Vila Real"}
            };

        Dictionary<int, string> cViseu = new Dictionary<int, string>
            {
                {1, "Armamar"},
                {2, "Carregal do Sal"},
                {3, "Castro Daire"},
                {4, "Cinfães"},
                {5, "Lamego"},
                {6, "Mangualde"},
                {7, "Moimenta da Beira"},
                {8, "Mortágua"},
                {9, "Nelas"},
                {10, "Oliveira de Frades"},
                {11, "Penalva do Castelo"},
                {12, "Penedono"},
                {13, "Resende"},
                {14, "S. João da Pesqueira"},
                {15, "S. João do Sul"},
                {16, "Santa Comba Dão"},
                {17, "Sátão"},
                {18, "Sernancelhe"},
                {19, "Tabuaço"},
                {20, "´Tarouca"},
                {21, "Tondela"},
                {22, "Vila Nova de Paiva"},
                {23, "Viseu"},
                {24, "Vouzela"}
            };

        public MainWindow()
        {
            InitializeComponent();

            ls = new List<Alunos>();
            xs = new XmlSerializer(typeof(List<Alunos>));
            tbNome.MaxLength = 20;
            tbNum.MaxLength = 5;
            //tbCp.MaxLength = 8;

            cbDistrito.ItemsSource = distritos.Values;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("alunos.xml", FileMode.Open, FileAccess.Write);
            Alunos aluno = new Alunos();
            aluno.Nome = tbNome.Text;
            aluno.Num = int.Parse(tbNum.Text);
            //aluno.Cp = tbCp.Text;
            aluno.Distrito = dT;
            aluno.Concelho = cT;

            int i, j = 0;
            int nc = DataGrid.Items.Count;

            for (i = 0; i < nc; i++ )
            {
                if (aluno.Num == ls[i].Num)
                {
                    j = 1;                               
                }
                else
                {
                    
                }
            }

            if (j == 0)
            {
                ls.Add(aluno);

                xs.Serialize(fs, ls);
                fs.Close();

                lbDg.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                tbNome.Text = "";
                tbNum.Text = "";
                //tbCp.Text = "";
                lbDg.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Número repetido");

                xs.Serialize(fs, ls);
                fs.Close();
            }
        }
        private void btnLer_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("alunos.xml", FileMode.Open, FileAccess.Read);
            ls = (List<Alunos>)xs.Deserialize(fs);

            DataGrid.CanUserAddRows = false;
            DataGrid.ItemsSource = ls;
            fs.Close();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbDistrito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dT = cbDistrito.SelectedItem.ToString();

            switch (dT)
            {
                case "Açores":
                    cbConcelho.ItemsSource = cAcores.Values;
                    break;

                case "Aveiro":
                    cbConcelho.ItemsSource = cAveiro.Values;
                    break;

                case "Beja":
                    cbConcelho.ItemsSource = cBeja.Values;
                    break;

                case "Braga":
                    cbConcelho.ItemsSource = cBraga.Values;
                    break;

                case "Bragança":
                    cbConcelho.ItemsSource = cBraganca.Values;
                    break;

                case "Castelo Branco":
                    cbConcelho.ItemsSource = cCasteloBranco.Values;
                    break;

                case "Coimbra":
                    cbConcelho.ItemsSource = cCoimbra.Values;
                    break;

                case "Évora":
                    cbConcelho.ItemsSource = cEvora.Values;
                    break;

                case "Faro":
                    cbConcelho.ItemsSource = cFaro.Values;
                    break;

                case "Guarda":
                    cbConcelho.ItemsSource = cGuarda.Values;
                    break;

                case "Leiria":
                    cbConcelho.ItemsSource = cLeiria.Values;
                    break;

                case "Lisboa":
                    cbConcelho.ItemsSource = cLisboa.Values;
                    break;

                case "Madeira":
                    cbConcelho.ItemsSource = cMadeira.Values;
                    break;

                case "Portalegre":
                    cbConcelho.ItemsSource = cPortalegre.Values;
                    break;

                case "Porto":
                    cbConcelho.ItemsSource = cPorto.Values;
                    break;

                case "Santarém":
                    cbConcelho.ItemsSource = cSantarem.Values;
                    break;

                case "Setúbal":
                    cbConcelho.ItemsSource = cSetubal.Values;
                    break;

                case "Viana do Castelo":
                    cbConcelho.ItemsSource = cVianadoCastelo.Values;
                    break;

                case "Vila Real":
                    cbConcelho.ItemsSource = cVilaReal.Values;
                    break;

                case "Viseu":
                    cbConcelho.ItemsSource = cViseu.Values;
                    break;
            }

        }

        private void cbConcelho_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbConcelho.SelectedIndex == -1)
            {
                
            }
            else
            {
                cT = cbConcelho.SelectedItem.ToString();
            }
        }

        //TextBox do Codigo Postal
        /*
        private void tbCp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int pos = 0;
                int len = tbCp.Text.Length;
                string s = tbCp.Text;

                pos = 4;
                while (true)
                {
                    if (pos >= len) break;
                    char c = s[pos];
                    if (char.IsDigit(c))
                    {
                        s = s.Insert(pos, "-");
                        tbCp.Text = s;
                    }
                    pos += 5;
                    tbCp.Select(tbCp.Text.Length, 1);
                    tbCp.ScrollToEnd();
                    tbCp.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */
    }
}