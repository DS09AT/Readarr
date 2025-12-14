# Shelvance Website

Statische Website für das Shelvance-Projekt.

## Struktur

```
/
├── index.html           # Hauptseite
├── assets/
│   ├── css/
│   │   └── style.css   # Hauptstilsheet mit CSS-Variablen
│   ├── js/
│   │   └── main.js     # JavaScript-Funktionalitäten
│   └── images/         # Bilder und Icons
└── README.md           # Diese Datei
```

## Erweiterungen

Die Seite ist vorbereitet für:
- **Zusätzliche Seiten**: Z.B. `/features.html`, `/pricing.html`, `/blog/`
- **CSS-Modularisierung**: Separate Dateien pro Komponente möglich
- **JavaScript-Module**: Z.B. Navigation, Scroll-Effekte, Formulare
- **Assets**: Images, Icons, Fonts
- **CMS-Integration**: HTML ist semantisch aufgebaut für einfache Integration

## CSS-Variablen

Alle Farben und Abstände sind zentral definiert und können leicht angepasst werden:
- `--primary-color`: Hauptfarbe (Blau)
- `--secondary-color`: Sekundärfarbe
- `--accent-color`: Akzentfarbe
- `--spacing-unit`: Basis-Spacing (1rem)

## Responsive Design

Die Website ist vollständig responsive und optimiert für:
- Desktop (1200px+)
- Tablet (768px - 1199px)
- Mobile (unter 480px)
