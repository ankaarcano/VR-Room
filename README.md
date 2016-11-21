# VR-Room
Aplikacja VR wykorzystująca Google Cardboard SDK

Instrukcja:
Przy odpalaniu aplikacji zbuildowane na PC i play modu w Unity jako drugiej aplikcaji pokójtrzeba stworzyć w Unity ( to daje możliwość poruszania się [Alt+mysz]). 


Pierwsza wersja projektu - branch: master

Udało mi się pobrać transform z prefabu obiektu(Cube1) i przypisać jego wartości drugiemu obiektowi(Slup). Jednak podczas działania aplikcji wartości Transforma, który pobieram są cały czas takie same, nie zmieniają się niezależnie od tego jakby się ten obiekt nie przemieszczał. Sprawdziłam, że te wartości odpowiadają tym z przed inicjalizacji prefabu na serwerze. Nie wiem jak sobie z tym porabić żeby można było pobierać aktualne dane. Napisałam posta na forum Unity Answers ale nikt nie odpisał.


Druga wersja projektu - branch: 2kamery

Tutaj stworzyłam nieco zmodyfikowany prefab CardboardMain - prefab CardMain. W CardboardMain jest podpięty Head i to on odpowiada za obroty tego prefabu więc skoro dzieci dziedziczą po rodzicach pozycję i obrót to podpięłam do niego osobną kamerę. W skrypcie PlayerSetup wyłaczam jedną z kamer w odpowiednich aplikacjach. Jednak moja dodana kamera nadal się nie obraca, chociaż pozycję zmienia tak jak powinna.

Trzecia wersja projektu - branch: 2kamery-naśladowanie
Wszystko działa tylko nie mogę wyłączyć Obiektu "Head" na kliencie przez co jest na nim dyskoteka
