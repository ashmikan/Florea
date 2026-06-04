<h1 align="center">🌹 Floréa — Flowers Shop 🌹</h1>

Welcome to Floréa — a small ASP.NET Core MVC sample application showcasing a boutique flower shop UI and a delivery tracking experience.

---

**Quick status**
- Project: Floréa
- Framework: .NET
- Key pages: Home, Flowers, Cart, Delivery Tracking, About

---

**Interactive checklist**
- [ ] Build the project
- [ ] Run locally
- [ ] Open the Delivery Tracking page
- [ ] Tweak styles or navbar

---

**Prerequisites**
- .NET SDK installed (recommended: latest stable)
- Git (optional)
- Node/npm only required if you add front-end tooling

**Quick start (local)**
1. Restore and build:

```powershell
dotnet restore
dotnet build Floréa.csproj
```

2. Run locally:

```powershell
dotnet run --project Floréa.csproj
```

3. Open a browser at `https://localhost:5001` (or the URL printed by dotnet run). Navigate to the Delivery Tracking page via the navbar or directly at `/Home/DeliveryTracking`.

---

**Files you will edit often**
- Main stylesheet: [wwwroot/css/site.css](wwwroot/css/site.css)
- Delivery tracking view: [Views/Home/DeliveryTracking.cshtml](Views/Home/DeliveryTracking.cshtml#L1-L240)
- Navbar partial: [Views/Shared/_OvalNavbar.cshtml](Views/Shared/_OvalNavbar.cshtml#L1-L80)
- Home controller actions: [Controllers/HomeController.cs](Controllers/HomeController.cs#L1-L120)

---

**Why styles sometimes don't apply**
Common causes when CSS changes appear to be ignored:
- Load order: CSS included later in the page will override earlier rules. Check `Views/Shared/_Layout.cshtml` where styles are referenced.
- Specificity: Bootstrap utility classes or rules in other stylesheets may be more specific or loaded after `site.css`.
- Cache: Hard-refresh your browser (Ctrl+F5) or disable cache in DevTools while developing.
- Broken HTML nesting: Missing closing tags will prevent selectors from matching — verify Razor views compile.

How to troubleshoot quickly:
- Open DevTools → Elements → select the element → Styles pane to see the winning rule and file.
- If overridden, either move the rule later, increase specificity (e.g. `.tracking-page .tracking-item { ... }`), or adjust the stylesheet order.

---

**Delivery Tracking: common edits**
- To change the layout or copy: edit [Views/Home/DeliveryTracking.cshtml](Views/Home/DeliveryTracking.cshtml#L1-L240).
- To adjust the order-details card visuals: edit the tracking selectors in [wwwroot/css/site.css](wwwroot/css/site.css#L1500-L1860). Use the `.tracking-page` prefix to keep styles scoped.
- Example: style the primary action (`Call courier`) with a light-blue background by adding a rule such as:

```css
.tracking-page .tracking-actions .btn.btn-primary.tracking-action-btn {
  background: linear-gradient(90deg, #dff6ff 0%, #bfefff 100%);
  color: #003a5a;
}
```

---

**Navbar (Track button)**
- The Track item lives in: [Views/Shared/_OvalNavbar.cshtml](Views/Shared/_OvalNavbar.cshtml#L1-L80).
- If the last pill overflows the rounded capsule, check the wrapper width (there's a `max-width` inline style on the `.oval-nav` container). You can adjust it in the partial or add responsive CSS in `site.css`.

---

**Developer workflows**
- Commit small, focused changes (UI, CSS, controller) separately.
- Suggested commit flow:
  - `git add wwwroot/css/site.css` → `git commit -m "UI: Fix tracking styles"`
  - `git add Views/Shared/_OvalNavbar.cshtml` → `git commit -m "UI: Update navbar"`

---

**Run the app (Windows PowerShell)**

```powershell
cd "c:\Users\Ashmika\OneDrive\Desktop\Floréa"
dotnet restore
dotnet build
dotnet run --project Floréa.csproj
```

---

**Testing & Validation**
- Check Razor syntax with a build: `dotnet build`.
- Validate CSS quickly by opening the page and using DevTools; there is no automated CSS test included by default.

---

<h2 align="center">Thank You! 👩🏼‍💻 </h2>

<div align="center">
Credit: <a href="https://github.com/ashmikan">Ashmika Nathali </a>
Last Edited on: 03/06/2026
</div>