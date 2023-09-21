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
- [ ] UI tylko z dostarczonych assetów
- [ ] oceniana będzie optymalizacja
- [ ] obiekt
  - [ ] spawnuje się w losowym widocznym miejscu
  - [ ] nie dotyka innych obiektów
  - [ ] posiada 3 życia
  - [ ] obiekty i pociski mają wizualną reprezentacje

## Opis gry do zrealizowania:
- [ ] Gra rozpoczyna się poprzez wyświetlenie okna wyboru liczby obiektów (50, 100, 250, 500) - widocznym na mockupie
- [ ] Po wyborze liczby obiektów udostępnia się możliwość rozgrywki (jak na mockupie)
- [ ] Po kliknięciu start wszystkie obiekty spawnują się w tym samym czasie
- [ ] Każdy z obiektów obraca się o losową wartość (0,360) stopni, co losowy czas (0,1) sekund.
- [ ] Co sekundę każdy z obiektów wystrzeliwuje pocisk skierowany w stronę w którą aktualnie jest obrócony.
- [ ] Pocisk może trafić w zespawnowany (1 ze 50/100/250/500) obiekt.
- [ ] Po trafieniu obiekt traci jedno ze swoich żyć i znika z planszy.
- [ ] Jeżeli obiekt ma więcej niż 1 dostępne życie wraca po 2 sekundach od śmierci na planszę i wykonuje wyżej opisaną mechanikę.
- [ ] Gra toczy się aż do momentu gdy wszystkie obiekty nie znikną z planszy na zawsze prócz jednego.
- [ ] Po zakończeniu gry pojawia się Button "Main menu", który pozwala włączyć grę na nowo (jak na mockupie) - wraca do okienka z wyborem liczby obiektów.
