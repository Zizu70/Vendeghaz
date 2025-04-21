-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 21. 04:06
-- Kiszolgáló verziója: 10.4.27-MariaDB
-- PHP verzió: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `vendeghaz`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `workers`
--

CREATE TABLE `workers` (
  `w_id` bigint(20) UNSIGNED NOT NULL,
  `w_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `w_password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `w_role` enum('admin','dolgozó') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `workers`
--

INSERT INTO `workers` (`w_id`, `w_name`, `w_password`, `w_role`) VALUES
(1, 'A', 'Aa1', 'admin'),
(2, 'B', 'Bb2', 'dolgozó'),
(3, 'C', 'Cc3', 'admin'),
(4, 'd', 'Dd4', 'dolgozó');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `workers`
--
ALTER TABLE `workers`
  ADD PRIMARY KEY (`w_id`),
  ADD UNIQUE KEY `w_name` (`w_name`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `workers`
--
ALTER TABLE `workers`
  MODIFY `w_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
