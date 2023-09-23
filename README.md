_<details><summary>Original README</summary>_
Wymagana wersja Unity (do wyboru jedna z podanych):
2022.3.4f1
2022.3.0f1
2021.3.28f1
Dostarczenie projektu: Git

Wytyczne:

- gra nie musi posiadać assetów innych niż te dostarczone, elementy
gamepleyowe mogą zostać stworzone na assetach standardowo dostępnych w
Unity
- UI ma zostać zbudowane TYLKO z elementów dostarczonych
- gra nie musi posiadać muzyki/dźwięków
- obiekt posiada 3 życia
- każdy obiekt spawnuje się w losowym (widocznym) miejscu na planszy
- pierwsza pozycja spawnu NIE MUSI równać się każdym kolejnym pozycjom
tego samego obiektu po stracie życia
- obiekty NIE POWINNY się stykać
- nie liczą się efekty wizualne w gameplayu a optymalizacja działania
gry
- zarówno obiekt, jak i jego pocisk musi mieć swoją wizualną
reprezentację


Opis gry do zrealizowania:

Gra rozpoczyna się poprzez wyświetlenie okna wyboru liczby obiektów (50,
100, 250, 500) - widocznym na mockupie.
Po wyborze liczby obiektów udostępnia się możliwość rozgrywki (jak na
mockupie).
Po kliknięciu start wszystkie obiekty spawnują się w tym samym czasie.
Każdy z obiektów obraca się o losową wartość (0,360) stopni, co losowy
czas (0,1) sekund.
Co sekundę każdy z obiektów wystrzeliwuje pocisk skierowany w stronę w
którą aktualnie jest obrócony.
Pocisk może trafić w zespawnowany (1 ze 50/100/250/500) obiekt. Po
trafieniu obiekt traci jedno ze swoich żyć i znika z planszy.
Jeżeli obiekt ma więcej niż 1 dostępne życie wraca po 2 sekundach od
śmierci na planszę i wykonuje wyżej opisaną mechanikę.
Gra toczy się aż do momentu gdy wszystkie obiekty nie znikną z planszy
na zawsze prócz jednego.
Po zakończeniu gry pojawia się Button "Main menu", który pozwala włączyć
grę na nowo (jak na mockupie) - wraca do okienka z wyborem liczby
obiektów.
</details>

## Wersja Unity
- [x] 2022.3.4f1
- [ ] 2022.3.0f1
- [ ] 2021.3.28f1

## Wytyczne
- [x] UI tylko z dostarczonych assetów
- [ ] oceniana będzie optymalizacja
- [x] obiekt:
  - [x] spawnuje się w losowym widocznym miejscu
  - [x] nie dotyka innych obiektów
  - [x] posiada 3 życia
  - [x] obiekty i pociski mają wizualną reprezentacje


## Opis gry
- [x] Gra rozpoczyna się poprzez wyświetlenie okna wyboru liczby obiektów
<details><summary>mockup</summary>

![Mockup1](https://github.com/Vheos/Interview.Naptime/assets/9155825/42ba144e-8053-461d-97ab-60379d3c3442)  
</details>

- [x] Po wyborze liczby obiektów udostępnia się możliwość rozgrywki
<details><summary>mockup</summary>

![Mockup2](https://github.com/Vheos/Interview.Naptime/assets/9155825/e36ded54-2f66-4f2a-8c11-815e6c168736)
</details>

- [x] Po kliknięciu start wszystkie obiekty spawnują się w tym samym czasie
- [x] Każdy z obiektów obraca się o 0-360 stopni co 0-1 sekund
- [x] Co 1 sekundę każdy z obiektów wystrzeliwuje przed siebie pocisk 
- [x] Jeśli pocisk trafi w obiekt:
  - [x] obydwoje się despawnują
  - [x] obiekt traci 1 życie
  - [x] jeżeli obiekt nadal ma więcej niż 1 życie, respawnuje się po 2 sekundach
- [x] Gra kończy się jak zostanie tylko 1 obiekt
- [x] Po zakończeniu gry pojawia się przycisk "Main menu", który wraca do wyboru liczby obiektów
<details><summary>mockup</summary>
  
![Mockup3](https://github.com/Vheos/Interview.Naptime/assets/9155825/cdf16ff1-ca2c-45d1-aa4e-780e4fbeae5f)
</details>

## Komentarz
- ...
