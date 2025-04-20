import { useState, useEffect } from 'react';

const Header = () => {
  const [theme, setTheme] = useState(() => localStorage.getItem('theme') || 'green');

  useEffect(() => {
    applyTheme(theme);
  }, [theme]);

  const applyTheme = (themeName) => {
    const existingLink = document.getElementById('theme-css');
    if (existingLink) existingLink.remove();

    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.id = 'theme-css';
    link.href = `/themes/theme-${themeName}.css`;
    document.head.appendChild(link);
  };

  const handleThemeChange = (e) => {
    const selected = e.target.value;
    localStorage.setItem('theme', selected);
    applyTheme(selected);
    setTheme(selected);
  };

  return (
    <header className="d-flex justify-content-between align-items-center px-4 py-3">
      <h1 className="m-0 d-flex align-items-center">
        <img
          src={`/vendeghaz_logo_${theme}.png`}
          alt="logo"
          style={{ height: '1.5em', marginRight: '0.5em' }}
        />
        Vendégház Vadaspark
      </h1>

      <select
        onChange={handleThemeChange}
        value={theme}
        className="form-select w-auto"
        style={{ maxWidth: '150px' }}
      >
        <option value="light">Világos</option>
        <option value="dark">Sötét</option>
        <option value="green">Zöld</option>
        <option value="brown">Barna</option>
      </select>
    </header>
  );
};

export default Header;
