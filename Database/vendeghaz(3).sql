-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 18. 21:46
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
CREATE DATABASE IF NOT EXISTS `vendeghaz` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `vendeghaz`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `adoption`
--

CREATE TABLE `adoption` (
  `a_id` bigint(20) UNSIGNED NOT NULL,
  `g_id` bigint(20) UNSIGNED NOT NULL,
  `u_id` bigint(20) UNSIGNED NOT NULL,
  `a_date` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `adoption`
--

INSERT INTO `adoption` (`a_id`, `g_id`, `u_id`, `a_date`) VALUES
(1, 1, 1, '2025-04-10'),
(2, 2, 2, '2025-04-12'),
(3, 1, 1, '2025-04-18');

-- --------------------------------------------------------

--
-- A nézet helyettes szerkezete `adoption_view`
-- (Lásd alább az aktuális nézetet)
--
CREATE TABLE `adoption_view` (
`a_id` bigint(20) unsigned
,`g_name` varchar(50)
,`g_species` enum('medve','farkas','muflon','őz','gím szarvas','róka','vadmacska','hiúz','aranysakál','mosómedve','sas','bagoly','páva','holló','vércse','varjú','ló','szamár','tehén','mangalica','baromfiak','dám szarvas','juh','kecske','nyúl','póniló')
,`g_gender` enum('hím','nőstény','ivartalanított')
,`g_birthdate` date
,`g_indate` date
,`g_inplace` varchar(100)
,`u_id` bigint(20) unsigned
,`u_name` varchar(255)
);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `guests`
--

CREATE TABLE `guests` (
  `g_id` bigint(20) UNSIGNED NOT NULL,
  `g_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `g_species` enum('medve','farkas','muflon','őz','gím szarvas','róka','vadmacska','hiúz','aranysakál','mosómedve','sas','bagoly','páva','holló','vércse','varjú','ló','szamár','tehén','mangalica','baromfiak','dám szarvas','juh','kecske','nyúl','póniló') NOT NULL,
  `g_gender` enum('hím','nőstény','ivartalanított') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `g_birthdate` date NOT NULL,
  `g_indate` date NOT NULL,
  `g_inplace` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `g_other` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `g_image` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp(),
  `deleted_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `guests`
--

INSERT INTO `guests` (`g_id`, `g_name`, `g_species`, `g_gender`, `g_birthdate`, `g_indate`, `g_inplace`, `g_other`, `g_image`, `created_at`, `updated_at`, `deleted_at`) VALUES
(1, 'Bubu', 'medve', 'hím', '2015-06-01', '2020-04-12', 'Börzsöny Észak Kelet', 'Szereti a mézet.', 'Bársony.jpg', '2025-04-18 16:38:56', '2025-04-18 17:54:40', '2025-04-18 17:22:44'),
(2, 'Fanni', 'őz', 'nőstény', '2018-03-22', '2021-07-15', 'Zemplén', 'Nagyon félénk.', NULL, '2025-04-18 16:38:56', NULL, NULL);

--
-- Eseményindítók `guests`
--
DELIMITER $$
CREATE TRIGGER `before_guest_insert` BEFORE INSERT ON `guests` FOR EACH ROW SET NEW.updated_at = NULL, 
    NEW.deleted_at = NULL
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_guest_soft_delete` BEFORE UPDATE ON `guests` FOR EACH ROW BEGIN
    IF NEW.deleted_at IS NULL AND OLD.deleted_at IS NULL AND NEW.g_name = OLD.g_name THEN
        SET NEW.deleted_at = NOW();
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_guest_update` BEFORE UPDATE ON `guests` FOR EACH ROW BEGIN
  SET NEW.updated_at = NOW();
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tickets`
--

CREATE TABLE `tickets` (
  `t_id` int(11) NOT NULL,
  `u_id` bigint(20) UNSIGNED NOT NULL,
  `t_date` date NOT NULL,
  `t_time` enum('de_9_óra','de_10_óra','de_11_óra','de_12_óra','du_13_óra','du_14_óra','du_15_óra','du_16_óra') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `t_piece` int(11) NOT NULL,
  `t_amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `tickets`
--

INSERT INTO `tickets` (`t_id`, `u_id`, `t_date`, `t_time`, `t_piece`, `t_amount`) VALUES
(1, 1, '2025-04-20', 'de_10_óra', 2, 3000),
(2, 2, '2025-04-21', 'du_15_óra', 4, 6000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `u_id` bigint(20) UNSIGNED NOT NULL,
  `u_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `u_email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `u_password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`u_id`, `u_name`, `u_email`, `u_password`, `created_at`) VALUES
(1, 'Kiss Anna', 'anna.kiss@example.com', 'jelszo123', '2025-04-18 16:38:43'),
(2, 'Nagy Péter', 'peter.nagy@example.com', 'titkos456', '2025-04-18 16:38:43');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `workers`
--

CREATE TABLE `workers` (
  `w_id` bigint(20) UNSIGNED NOT NULL,
  `w_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `w_password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `w_role` enum('admin','dolgozó') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `workers`
--

INSERT INTO `workers` (`w_id`, `w_name`, `w_password`, `w_role`, `created_at`) VALUES
(1, 'A', 'Aa1', 'admin', '2025-04-18 17:17:12'),
(2, 'julia', 'pass123', 'dolgozó', '2025-04-18 16:40:58');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `workers_guests`
--

CREATE TABLE `workers_guests` (
  `w_id` bigint(20) UNSIGNED NOT NULL,
  `g_id` bigint(20) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `workers_guests`
--

INSERT INTO `workers_guests` (`w_id`, `g_id`) VALUES
(1, 1),
(2, 2);

-- --------------------------------------------------------

--
-- Nézet szerkezete `adoption_view`
--
DROP TABLE IF EXISTS `adoption_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `adoption_view`  AS SELECT `adoption`.`a_id` AS `a_id`, `guests`.`g_name` AS `g_name`, `guests`.`g_species` AS `g_species`, `guests`.`g_gender` AS `g_gender`, `guests`.`g_birthdate` AS `g_birthdate`, `guests`.`g_indate` AS `g_indate`, `guests`.`g_inplace` AS `g_inplace`, `users`.`u_id` AS `u_id`, `users`.`u_name` AS `u_name` FROM ((`adoption` join `guests` on(`adoption`.`g_id` = `guests`.`g_id`)) join `users` on(`adoption`.`u_id` = `users`.`u_id`))  ;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `adoption`
--
ALTER TABLE `adoption`
  ADD PRIMARY KEY (`a_id`),
  ADD KEY `fk_adopt_user` (`u_id`),
  ADD KEY `fk_adopt_guest` (`g_id`);

--
-- A tábla indexei `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`g_id`);

--
-- A tábla indexei `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`t_id`),
  ADD KEY `fk_ticket_user` (`u_id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`u_id`),
  ADD UNIQUE KEY `name` (`u_name`),
  ADD UNIQUE KEY `email` (`u_email`);

--
-- A tábla indexei `workers`
--
ALTER TABLE `workers`
  ADD PRIMARY KEY (`w_id`),
  ADD UNIQUE KEY `w_name` (`w_name`);

--
-- A tábla indexei `workers_guests`
--
ALTER TABLE `workers_guests`
  ADD KEY `fk_workers` (`w_id`),
  ADD KEY `fk_guests` (`g_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `adoption`
--
ALTER TABLE `adoption`
  MODIFY `a_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `guests`
--
ALTER TABLE `guests`
  MODIFY `g_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `tickets`
--
ALTER TABLE `tickets`
  MODIFY `t_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `u_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `workers`
--
ALTER TABLE `workers`
  MODIFY `w_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `adoption`
--
ALTER TABLE `adoption`
  ADD CONSTRAINT `fk_adopt_guest` FOREIGN KEY (`g_id`) REFERENCES `guests` (`g_id`),
  ADD CONSTRAINT `fk_adopt_user` FOREIGN KEY (`u_id`) REFERENCES `users` (`u_id`);

--
-- Megkötések a táblához `tickets`
--
ALTER TABLE `tickets`
  ADD CONSTRAINT `fk_ticket_user` FOREIGN KEY (`u_id`) REFERENCES `users` (`u_id`);

--
-- Megkötések a táblához `workers_guests`
--
ALTER TABLE `workers_guests`
  ADD CONSTRAINT `fk_guests` FOREIGN KEY (`g_id`) REFERENCES `guests` (`g_id`),
  ADD CONSTRAINT `fk_workers` FOREIGN KEY (`w_id`) REFERENCES `workers` (`w_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
