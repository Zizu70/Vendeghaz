-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 18. 17:23
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
  `g_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `g_species` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `g_gender` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `g_birthdate` date NOT NULL,
  `u_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `a_date` date NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `adoption`
--

INSERT INTO `adoption` (`a_id`, `g_name`, `g_species`, `g_gender`, `g_birthdate`, `u_name`, `a_date`, `created_at`, `updated_at`, `deleted_at`) VALUES
(1, '', NULL, NULL, '0000-00-00', '', '2025-02-09', '2025-03-16 11:47:38', NULL, NULL),
(2, 'Bobo', NULL, NULL, '0000-00-00', 'Papp Hugó', '2024-02-10', '2025-03-16 11:47:38', NULL, NULL),
(3, 'Hóvirág', NULL, NULL, '0000-00-00', 'Szabó Orsolya', '2025-02-12', '2025-03-16 11:47:38', NULL, NULL),
(4, 'Bobo', NULL, NULL, '0000-00-00', 'Papp Hugó', '2025-02-15', '2025-03-16 11:47:38', NULL, NULL),
(5, 'Mózes', NULL, NULL, '0000-00-00', 'Papp Hugó', '0000-00-00', '2025-04-05 18:15:33', NULL, NULL),
(6, 'Borzas', NULL, NULL, '0000-00-00', 'Táltos Károly', '0000-00-00', '2025-04-05 18:17:15', NULL, NULL),
(7, 'Borzas', NULL, NULL, '0000-00-00', 'Admin', '2025-04-05', '2025-04-05 18:19:48', NULL, NULL),
(8, 'Bajnok', NULL, NULL, '0000-00-00', 'Szabó Orsolya', '2025-04-05', '2025-04-05 18:22:28', NULL, NULL),
(9, 'Bambi', NULL, NULL, '0000-00-00', 'Admin', '2025-04-05', '2025-04-05 18:24:10', NULL, NULL),
(10, 'Mózes', NULL, NULL, '0000-00-00', 'Szabó Orsolya', '2025-04-05', '2025-04-05 18:25:23', NULL, NULL),
(11, '2025-04-06', NULL, NULL, '0000-00-00', 'Mózes', '0000-00-00', '2025-04-06 10:36:28', NULL, NULL),
(12, 'Mimike', NULL, NULL, '0000-00-00', 'Papp Hugó', '2025-04-06', '2025-04-06 10:38:58', NULL, NULL),
(13, 'Mózes', NULL, NULL, '0000-00-00', 'Szabó Orsolya', '2025-04-06', '2025-04-06 13:03:36', NULL, NULL),
(14, 'Mózes', NULL, NULL, '0000-00-00', 'Admin', '2025-04-06', '2025-04-06 13:06:14', NULL, NULL),
(15, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Papp Hugó', '2025-04-06', '2025-04-06 14:26:32', NULL, NULL),
(16, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Papp Hugó', '2025-04-06', '2025-04-06 14:26:41', NULL, NULL),
(17, 'Borzas', 'róka', 'hím', '2025-02-14', 'Admin', '2025-04-06', '2025-04-06 14:31:55', NULL, NULL),
(18, 'Borzas', 'róka', 'hím', '2025-02-14', 'Juhász Emilia', '2025-04-06', '2025-04-06 14:34:24', NULL, NULL),
(19, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 14:39:48', NULL, NULL),
(20, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 14:41:55', NULL, NULL),
(21, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 14:43:25', NULL, NULL),
(22, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 14:49:12', NULL, NULL),
(23, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Juhász Emilia', '2025-04-06', '2025-04-06 14:52:57', NULL, NULL),
(24, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Papp Hugó', '2025-04-06', '2025-04-06 14:59:21', NULL, NULL),
(25, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Papp Hugó', '2025-04-06', '2025-04-06 15:00:57', NULL, NULL),
(26, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 16:54:03', NULL, NULL),
(27, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 16:55:29', NULL, NULL),
(28, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 17:01:26', NULL, NULL),
(29, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Admin', '2025-04-06', '2025-04-06 17:02:35', NULL, NULL),
(30, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Szabó Orsolya', '2025-04-11', '2025-04-11 08:58:32', NULL, NULL),
(31, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Szabó Orsolya', '2025-04-11', '2025-04-11 09:00:06', NULL, NULL),
(32, 'Mózes', 'farkas', 'hím', '2024-01-02', 'Szabó Orsolya', '2025-04-11', '2025-04-11 09:14:40', NULL, NULL);

--
-- Eseményindítók `adoption`
--
DELIMITER $$
CREATE TRIGGER `before_adoption_insert` BEFORE INSERT ON `adoption` FOR EACH ROW SET NEW.updated_at = NULL, 
    NEW.deleted_at = NULL
$$
DELIMITER ;

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
(1, 'Mózes', 'farkas', 'hím', '2024-01-03', '2024-03-13', 'Veresegyház Medve otthon.', 'Nagyon kedves és barátságos.', 'Mózes.jpg', '2025-02-16 16:15:24', '2025-02-16 16:15:24', NULL),
(2, 'Merse', 'vércse', 'hím', '2025-01-13', '2025-02-11', 'vougvl', NULL, NULL, '2025-02-16 16:15:32', '2025-04-12 22:44:38', NULL),
(3, 'Borzas', 'róka', 'hím', '2025-02-14', '2025-03-03', 'Budapesten találták 2 hetes kölyökként.', '', 'Borzas.jpg', '2025-02-16 16:18:15', '2025-04-13 12:22:48', '2025-04-13 12:22:48'),
(4, 'Fecske', 'bagoly', 'nőstény', '2025-01-12', '2025-02-10', 'ébh ', '', '', '2025-02-16 16:18:26', '2025-04-13 15:30:49', '2025-04-13 15:30:49'),
(5, 'Károly', 'vadmacska', 'hím', '2025-01-06', '2024-12-17', '', '', '', '2025-02-16 16:18:57', '2025-04-13 10:56:22', '2025-04-13 10:56:22'),
(6, 'Mimike', 'póniló', 'nőstény', '2024-08-12', '2024-11-11', 'JAVITVA', '', NULL, '2025-02-16 16:49:50', '2025-04-12 22:52:37', '2025-04-12 22:52:37'),
(7, '', '', '', '0000-00-00', '0000-00-00', '', NULL, NULL, '2025-03-29 21:21:58', '2025-04-13 00:23:03', NULL),
(8, '', '', '', '0000-00-00', '0000-00-00', '', NULL, NULL, '2025-03-29 21:54:54', '2025-04-13 01:01:03', NULL),
(9, 'Félix', 'juh', 'nőstény', '2024-12-09', '2025-01-13', 'fcsdv', '', NULL, '2025-03-29 21:59:44', '2025-04-12 22:42:22', NULL),
(10, 'Jazmin', 'kecske', '', '2024-12-15', '2024-12-23', 'Felvitel', '', '', '2025-03-29 23:21:09', '2025-04-13 15:13:44', '2025-04-13 15:13:44'),
(11, '', '', '', '0000-00-00', '0000-00-00', '', NULL, NULL, '2025-03-30 00:01:08', '2025-04-13 00:56:25', NULL),
(12, '', '', '', '0000-00-00', '0000-00-00', '', NULL, NULL, '2025-03-30 00:05:36', '2025-04-11 14:28:26', NULL),
(13, 'Szasza', 'nyúl', 'hím', '2025-02-21', '2025-02-23', 'bdfbydfb', 'ybfbydfbydb', 'Szasza.jpg', '2025-03-30 00:26:52', '2025-04-12 23:50:48', '2025-04-12 23:50:48'),
(14, '', '', '', '0000-00-00', '0000-00-00', '', NULL, NULL, '2025-04-11 11:10:52', '2025-04-11 14:31:34', NULL),
(15, 'Jákob', 'póniló', 'hím', '2025-01-02', '2025-01-31', 'cfjcj', '', '', '2025-04-12 22:33:55', '2025-04-13 01:04:22', '2025-04-13 01:04:22'),
(16, 'Hirshi', 'kecske', 'nőstény', '2024-07-01', '2024-11-27', 'xh yxhJAvított', '', NULL, '2025-04-12 23:36:46', '2025-04-13 15:34:06', '2025-04-13 15:34:06');

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
  `t_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `t_email` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `t_date` date NOT NULL,
  `t_time` enum('de_9_óra','de_10_óra','de_11_óra','de_12_óra','du_13_óra','du_14_óra','du_15_óra','du_16_óra') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `t_piece` int(11) NOT NULL,
  `t_amount` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `tickets`
--

INSERT INTO `tickets` (`t_id`, `t_name`, `t_email`, `t_date`, `t_time`, `t_piece`, `t_amount`, `created_at`, `updated_at`, `deleted_at`) VALUES
(1, 'Sz Z', 'a@a.hu', '2025-04-11', 'de_9_óra', 2, 2000, '2025-04-13 08:45:29', NULL, NULL),
(2, 'sadrgsdr', 'a@b.com', '2025-04-16', '', 22, 22000, '2025-04-13 12:40:00', '2025-04-13 12:40:00', '2025-04-13 12:40:00'),
(4, 'Morzsa', 'asdc@as.hu', '2025-04-29', '', 55, 55000, '2025-04-13 12:41:43', '2025-04-13 12:41:43', '2025-04-13 12:41:43'),
(9, 'Ferenc javított', 'a@a.hu', '2025-04-13', '', 5, 5000, '2025-04-13 12:58:04', '2025-04-13 12:58:04', NULL),
(10, 'géza', 'a@a.hu', '2025-04-13', 'de_9_óra', 8, 8000, '2025-04-13 15:16:37', '2025-04-13 15:16:37', '2025-04-13 15:16:37'),
(11, 'tamás', 'a@a.hu', '2025-04-15', 'du_15_óra', 15, 15000, '2025-04-13 14:33:59', '2025-04-13 14:33:59', '2025-04-13 14:33:59'),
(12, '', '', '0001-01-01', '', 0, 0, '2025-04-13 13:13:34', '2025-04-13 13:13:34', NULL),
(13, 'Sámson', 'a@a.hu', '2025-04-26', '', 99, 99000, '2025-04-13 13:10:27', '2025-04-13 13:10:27', '2025-04-13 13:10:27'),
(14, '', '', '0001-01-01', '', 0, 0, '2025-04-13 14:19:02', '2025-04-13 14:19:02', NULL),
(15, 'Delila Javítva', 'a@a.hu', '2025-04-13', 'du_13_óra', 13, 13000, '2025-04-13 14:38:02', '2025-04-13 14:38:02', '2025-04-13 14:38:02'),
(16, 'Góliát', 'gfghgf', '2025-04-20', 'de_9_óra', 20, 20000, '2025-04-13 15:12:11', '2025-04-13 15:12:11', '2025-04-13 15:12:11');

--
-- Eseményindítók `tickets`
--
DELIMITER $$
CREATE TRIGGER `before_ticket_insert` BEFORE INSERT ON `tickets` FOR EACH ROW SET NEW.updated_at = NULL, 
    NEW.deleted_at = NULL
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_ticket_soft_delete` BEFORE UPDATE ON `tickets` FOR EACH ROW BEGIN
    IF NEW.deleted_at IS NULL AND OLD.deleted_at IS NULL AND NEW.t_name = OLD.t_name THEN
        SET NEW.deleted_at = NOW();
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_ticket_update` BEFORE UPDATE ON `tickets` FOR EACH ROW BEGIN
  SET NEW.updated_at = NOW();
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `u_id` bigint(20) UNSIGNED NOT NULL,
  `u_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `u_email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `u_password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `u_role` enum('admin','user') NOT NULL DEFAULT 'user',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`u_id`, `u_name`, `u_email`, `u_password`, `u_role`, `created_at`, `updated_at`, `deleted_at`) VALUES
(1, 'Admin', 'admin@vendeghaz.hu', 'Admin1', 'admin', '2025-02-03 13:36:29', NULL, NULL),
(2, 'Papp Hugó', 'h.pap@gmail.com', 'hapci45', 'user', '2025-02-02 13:39:02', '2025-03-02 13:39:02', NULL),
(3, 'Juhász Emilia', 'emci@gmail.com', 'Svf452l', 'user', '2025-03-11 13:40:18', NULL, NULL),
(4, 'Táltos Károly', 'info@vendeghazmenedek.hu', 'Admin2', 'user', '2025-02-02 13:39:31', '2025-02-16 13:39:31', '2025-03-14 13:39:31'),
(5, 'Szabó Orsolya', 'borsoka@gmail.com', 'borsoka75', 'user', '2025-03-10 13:40:31', NULL, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `workers`
--

CREATE TABLE `workers` (
  `w_id` bigint(20) UNSIGNED NOT NULL,
  `w_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `w_password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `w_role` enum('admin','dolgozó') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `workers`
--

INSERT INTO `workers` (`w_id`, `w_name`, `w_password`, `w_role`, `created_at`, `updated_at`, `deleted_at`) VALUES
(1, 'A', 'Aa1', 'admin', '2025-03-22 18:49:29', '2025-03-22 18:48:02', NULL),
(2, 'Rozi', 'Rr2', 'admin', '2025-04-06 21:15:14', NULL, NULL),
(6, 'Zoli', 'Zz6', 'dolgozó', '2025-03-13 11:12:51', '2025-03-14 11:12:51', '2025-03-15 11:12:51'),
(7, 'Liza', 'Ll7', 'admin', '2025-03-15 10:16:27', '2025-03-15 16:58:34', NULL);

--
-- Eseményindítók `workers`
--
DELIMITER $$
CREATE TRIGGER `before_worker_insert` BEFORE INSERT ON `workers` FOR EACH ROW SET NEW.updated_at = NULL, 
    NEW.deleted_at = NULL
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_worker_soft_delete` BEFORE UPDATE ON `workers` FOR EACH ROW BEGIN
    IF NEW.deleted_at IS NULL AND OLD.deleted_at IS NULL AND NEW.w_name = OLD.w_name THEN
        SET NEW.deleted_at = NOW();
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_worker_update` BEFORE UPDATE ON `workers` FOR EACH ROW BEGIN
  SET NEW.updated_at = NOW();
END
$$
DELIMITER ;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `adoption`
--
ALTER TABLE `adoption`
  ADD PRIMARY KEY (`a_id`);

--
-- A tábla indexei `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`g_id`);

--
-- A tábla indexei `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`t_id`);

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
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `adoption`
--
ALTER TABLE `adoption`
  MODIFY `a_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT a táblához `guests`
--
ALTER TABLE `guests`
  MODIFY `g_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT a táblához `tickets`
--
ALTER TABLE `tickets`
  MODIFY `t_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `u_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `workers`
--
ALTER TABLE `workers`
  MODIFY `w_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
