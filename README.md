# FAMOT-app

![alt text](https://github.com/MichalDominik/FAMOT-app/blob/master/kategorie.PNG?raw=true)
![alt text](https://github.com/MichalDominik/FAMOT-app/blob/master/produkty.PNG?raw=true)
![alt text](https://github.com/MichalDominik/FAMOT-app/blob/master/produktyedytuj.PNG?raw=true)

# O aplikacji

Aplikacja do zarządzania produktami

Aplikacja wykorzystuje ASP.NET CORE w architekturze warstwowej. Backend tworzą trzy warstwy:

- warstwa "Repository" - wykorzystuje Entity Framework, aby stworzyć i aktualizować bazę danych na podstawie kodu,

- warstwa "Service" - zawiera metody do zarządzania bazą danych,

- warstwa "API" - zawiera kontrolery, które obsługują żądania REST.

Frontend wykorzystuje technologię Angular. Składa się z dwóch komponentów: "category" oraz "product".

Każdy z komponentów posiada dwie warstwy logiczne:

- warstwa "Service" - wysyła odpowiednie żądania REST,

- warstwa "Component" - obsługuje logikę komponentu.

Frontend korzysta z Angular Material.

# Zaimplementowana funkcjonalność

- Dodanie kategorii

- Usunięcie kategorii

- Dodanie produktu

- Usunięcie produktu

- Aktualizacja produktu (nazwa, kategoria, opis)

Zabezpieczenia:

- nazwa oraz kategoria jest wymagana przy dodawaniu produktu

- nie można dodać kategorii lub produktu o już istniejącej nazwie

- nie można usunąć kategorii, do której należą jakieś produkty

---

Michał Dominik

Zadanie rekrutacyjne dla FAMOT Pleszew
