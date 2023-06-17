# Fizyka - Ruchy Browna

Michał Tracichleb 122028
* Grupa wykładowa: II_Inf_NW_nl_3
* Grupa konwersatoryjna: 21_Inf_NW_nl_3

## Użycie metody Monte-Carlo do symulacji ruchów Browna

Języku programowania C# - program który wykorzystuje generator liczb pseudolosowych oblicza: 
1) położenie cząsteczki po n krokach xn, i yn . (dla n = 102, 103, …1020)
2) długość wektora przesunięcia cząsteczki po n krokach.
3) wyniki prezentuje się na stronie i można  go pobrać z bazy danych w pliku dane.xls
4) aplikacja pokazuje poszczególne ruchy cząsteczki (wykres) w przestrzeni 2D

Metody Monte Carlo to ogólna nazwa metod rozwiązywania złożonych problemów występujących w różnych dziedzinach, od fizyki, przez matematykę, teorię gier, do ekonomii, z wykorzystaniem komputerowego - generowania liczb pseudolosowych. 

## Modelowanie ruchów Browna

W 1828 roku szkocki botanik Robert Brown opublikował sprawozdanie ze swoich wieloletnich badań. Posługując się mikroskopem, zaobserwował, że drobiny kurzu, sadzy i pyłki kwiatowe zawieszone w wodzie i innych płynach wykonują nieustanne i nieregularne ruchy podobne błądzenia. Po wielu eksperymentach Brown wysnuł wniosek, że ruchy występują samoczynnie. Spróbujmy za pomocą symulacji komputerowej zaprezentować przykładową trajektorię cząsteczki pływającej po powierzchni cieczy i obliczyć przemieszczenie tej cząsteczki w określonym czasie. Ponieważ interesują nas ruchy cząsteczki na powierzchni, obliczenia przeprowadzimy w przestrzeni dwuwymiarowej (2D). Załóżmy, że nasza cząsteczka startuje w początku kartezjańskiego układu współrzędnych. Ustalmy też, że w każdym kroku cząsteczka przemieszcza się w dowolnym kierunku o wektor stałej długości - dla uproszczenia przyjmujemy 1 za długość kroku.

Interesuje nas wypadkowy wektor przesunięcia .v cząsteczki po n ruchach. Czy średnia długość tego wektora będzie różna od zera oraz czy ugość ta zależy od liczby wykonanych kroków?

## Zadanie zrealizujemy następująco:
* Cząsteczka startująca w początku układu współrzędnych może wykonać ruch w dowolnym kierunku. Musimy wyznaczyć współrzędną x1, i y1. nowego położenia cząsteczki po pierwszym ruchu. Z położenia o współrzędnych x1, i y1., cząsteczka wykonuje następny ruch w dowolnym kierunku, obliczamy wówczas położenie x2 i y2. cząsteczki po drugim kroku itd.
* Na koniec wyznaczamy położenie cząsteczki po n krokach xn, i yn . Pozostaje nam już tylko wyznaczyć długość wektora przesunięcia cząsteczki po n krokach. Ponieważ cząsteczka startowała z punktu o współrzędnych (0, 0), długość ta wyniesie *tu_powinien_być_wzór*
* Kierunek przesunięcia cząsteczki w każdym kroku obliczymy za pomocą generatora liczb losowych, który wylosuje kąt z przedziału <0; 2π>
* Następnie dla wyznaczenia współrzędnych posłużymy się wzorami:

      var vectorLength = 1;
      List<Coordinate> coordinates = new List<Coordinate>{
                 new CoordinateView
                 {
                        Step = 0,
                        ValueX = 0,
                        ValueY = 0,
                        Vector = 0
                  },
                };

      vectorAangle = GenerateRandomDouble(2 * Math.PI);
      
      x = coordinates[i].ValueX + (vectorLength * Math.Cos(vectorAangle));
      y = coordinates[i].ValueY + (vectorLength * Math.Sin(vectorAangle));
     
  gdzie : k = 0, 1,…, n, r – długość jednego kroku (my przyjęliśmy 1), *fi* jest to kąt między kierunkiem ruchu cząsteczki a osią 0X.
