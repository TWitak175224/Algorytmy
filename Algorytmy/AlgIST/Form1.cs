namespace AlgIST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] ints = { 1, 4, 6, 2, 65, 10, 23 };

            MessageBox.Show(babelkowe(ints));
        }
        private string babelkowe(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] > a[i])
                {
                    int swapper = a[i - 1];
                    a[i - 1] = a[i];
                    a[i] = swapper;
                }


            }
            string posegregowane = "";
            for (int i = 0; i < a.Length; i++) { posegregowane = posegregowane + a[i] + ","; }
            return posegregowane;
        }
        private void insertion(int[] a)
        {

            for (int i = 1; i < a.Length; i++)
            {
                int klucz_sortowania = a[i], j = i - 1;//klucz sortowania - element który sprawdzamy gdze umieœciæ a przy okazji nasz temporary, j=od którego elementu ma jechaæ
                while (j >= 0 && a[j] > klucz_sortowania)//jeœli j>=0 i element a[j](element poprzedni w pierwszym przebiegu)>od sprawdzanego to rób pêtlê
                {
                    a[j + 1] = a[j];//przesuñ element a[j] jedno miejsce w prawo
                    j--;//poleæ dalej ze sprawdzaniem
                }
                a[j + 1] = klucz_sortowania;
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            int[] ints = { 1, 4, 6, 2, 65, 10, 23 };
            insertion(ints);
            MessageBox.Show(wypisz(ints));
        }

        static void mojezlozenie(int[] a, int lewa, int srodek, int prawa)
        {
            int dlugosc_lewej = srodek - lewa + 1;//plus jeden aby zapewnic œrodek
            int dlugosc_prawej = prawa - srodek;

            int[] tablica_Lewa = new int[dlugosc_lewej];//stworzenie tablicy lewej o odpowiedniej dlugosci
            int[] tablica_prawa = new int[dlugosc_prawej];//stworzenie prawej tablicy o odpowiedniej tablicy
            int i = 0, j = 0;//stworzenie iteratorów globalnych

            //przepisanie tablic
            for (; i < dlugosc_lewej; i++)
            {
                tablica_Lewa[i] = a[lewa + i];//przypisanie elementów z tablicy a na odpowiednie miejsca w lewej tablicy
            }
            for (; j < dlugosc_prawej; j++)
            {
                tablica_prawa[j] = a[srodek + j + 1];//przypisanie elementów z tablicy a na odpowiednie miejsca w prawej tablicy
            }
            i = 0;//ponowna zmiana iteratorów na 0
            j = 0;
            int k = lewa;//ustawienie iteratora do listy i umieszczania w miejscach

            while(i< dlugosc_lewej && j < dlugosc_prawej)
            {
                if (tablica_Lewa[i] < tablica_prawa[j])//porównujemy elementy w tablicach dopóki nie skoñcz¹ siê w jednej
                {
                    a[k] = tablica_Lewa[i];
                    i++;
                }
                else {
                    a[k] = tablica_prawa[j];
                    j++;
                }
                k++;
            }
            while(i < dlugosc_lewej)//uzupe³niamy elementami w tablicy w której zosta³y elementy
            {
                a[k] = tablica_Lewa[i];
                i++;
                k++;
            }
            while (j < dlugosc_prawej) {
                a[k] = tablica_prawa[j];
                j++;
                k++;
            }
        }

        static void mojmerge(int[] a, int poczatek, int koniec) {
            if (poczatek < koniec)
            {
                int srodek = poczatek + (koniec - poczatek) / 2;
                mojmerge(a, poczatek, srodek);
                mojmerge(a, srodek + 1, koniec);
                mojezlozenie(a, poczatek, srodek, koniec);
            }
        }
        
        private string wypisz(int[] a)
        {
            string posegregowane = "";
            for (int i = 0; i < a.Length; i++) { posegregowane = posegregowane + a[i] + ","; }
            return posegregowane;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int[] ints = { 1, 4, 6, 2, 65, 10, 23 };
            mojmerge(ints, 0, ints.Length - 1);
            MessageBox.Show(wypisz(ints));


        }

        static int UstawieniePivota(int[] a, int dolnyindeks, int gornyindeks) {
            int pivot = a[gornyindeks];
            int i = dolnyindeks;
            int temp;
            for(int j=dolnyindeks; j < gornyindeks; j++)
            {
                if(a[j] < pivot)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                }
            }
            temp = a[i];
            a[i] = a[gornyindeks];
            a[gornyindeks] = temp;
            return i;
        }

        static void mojQuick(int[]a,int  dolnyIndeks,int gornyIndeks)
        {
            if (dolnyIndeks < gornyIndeks) {
                int miejscepivota = UstawieniePivota(a, dolnyIndeks, gornyIndeks);
                mojQuick(a,dolnyIndeks, miejscepivota-1);
                mojQuick(a, miejscepivota + 1, gornyIndeks);            
            
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            int[] ints = { 1, 4, 6, 2, 65, 10, 23 };
            mojQuick(ints, 0, ints.Length - 1);
            MessageBox.Show(wypisz(ints));
        }
        static int[] MojCount(int[] a)
        {
            int N = a.Length;
            int M = 0;
            for (int i = 0; i < N; i++) {
                if (M < a[i]) { //znajdywanie najwiêkszej liczby w tablicy wejœciowej
                    M = a[i];
                }
            }
            int[] tablicaLiczaca = new int[M+1];
            //zliczanie elementów
            for (int i = 0; i < N; i++)
            {
                tablicaLiczaca[a[i]]++;
            }
            for (int i = 1; i <= M; i++) {
                tablicaLiczaca[i] = tablicaLiczaca[i] + tablicaLiczaca[i - 1];//która w kolejnoœci jest ostatnia cyfra danego miejsca            
            }
            int[] tablicaWyjscia = new int[N];
            //tworzenie wyjœciowej ze zliczaj¹cej
            for (int i = N - 1; i >= 0; i--) {
                tablicaWyjscia[tablicaLiczaca[a[i]] - 1] = a[i];//tablicaWyjscia[tablicaLiczaca[a[i]] w tablicy wyjœcia w miejscu w którym stoi iloœæ elementów i z tablicy wejœcia w tablicy zlicaj¹cej pomniejszonej o 1 aby zachowaæ to ¿e tablice zaczynaj¹ siê od 0 
                tablicaLiczaca[a[i]]--;//pomnijesz odpowiednie miejsce w tablicy zliczaj¹cej o 1
            }
            return tablicaWyjscia;
        }


        
        private void button5_Click(object sender, EventArgs e)
        {
            int[] ints = { 1, 4, 6, 2, 65, 10, 23 };
            int[] outputarr = new int[ints.Length];
            outputarr = MojCount(ints);
            MessageBox.Show(wypisz(outputarr));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            for (int i = 0; i < 9; i++)
            {
                lista.AddFirst(i);
            }
            MessageBox.Show(lista.ToStringi());
            for (int i = 0; i < 9; i++)
            {
                lista.RemoveFirst();
            }
            MessageBox.Show(lista.ToStringi());
            for (int i = 0; i < 9; i++)
            {
                lista.AddLast(i);
            }
            MessageBox.Show(lista.ToStringi());
            for (int i = 0; i < 9; i++)
            {
                lista.RemoveLast();
            }
            MessageBox.Show(lista.ToStringi());
        }

    }
}
