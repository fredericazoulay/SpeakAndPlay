using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.Helpers
{
    public static class NumberToWord
    {
        private static string[] jusqueSeize_En = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety", "one hundred", "one thousand", "one million", "one billion", "one trillion" };
        private static string[] jusqueSeize_Fr = { "zero", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingts", "quatre-vingt-dix", "cent", "mille", "un million", "un milliard", "un billion" };
        private static string[] jusqueSeize_Sp = { "zero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa", "cien", "mil", "un millón", "mil millones", "un billón" };
        private static string[] jusqueSeize_It = { "zero", "uno", "due", "tre", "quattro", "cinque", "sei", "sette", "otto", "nove", "dieci", "undici", "dodici", "tredici", "quattordici", "quindici", "sedici", "diciassette", "diciotto", "diciannove", "venti", "trenta", "quaranta", "cinquanta", "sessanta", "settanta", "ottanta", "novanta", "cento", "mille", "un milione", "un miliardo", "un bilione" };
        private static string[] jusqueSeize_Po = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "catorze", "quinze", "dezasseis", "dezassete", "dezoito", "dezanove", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa", "cem", "mil", "um milhão", "mil milhões", "um bilião" };
        private static string[] jusqueSeize_Al = { "zero", "eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun", "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig", "hundert", "tausend", "eine Million", "eine Milliarde", "eine Billion" };


        /*
        Liste de nombres en anglais :
        1 – one
        2 – two
        3 – three
        4 – four
        5 – five
        6 – six
        7 – seven
        8 – eight
        9 – nine
        10 – ten
        11 – eleven
        12 – twelve
        13 – thirteen
        14 – fourteen
        15 – fifteen
        16 – sixteen
        17 – seventeen
        18 – eighteen
        19 – nineteen
        20 – twenty
        30 – thirty
        40 – forty
        50 – fifty
        60 – sixty
        70 – seventy
        80 – eighty
        90 – ninety
        100 – one hundred
        1 000 – one thousand
        un million – one million
        un milliard – one billion
        un billion – one trillion
        // ***********************************
        Règles de numération en anglais
        Les chiffres de zéro à neuf sont rendus par des mots spécifiques, de même que les nombres de dix à douze : zero[0], one[1], two[2], three[3], four[4], five[5], six[6], seven[7], eight[8], nine[9], ten[10], eleven[11] et twelve[12].
        De treize à dix-neuf, les nombres sont formés à partir des chiffres de un à neuf auxquels on ajoute le suffixe -teen : thirteen[13], fourteen[14], fifteen[15], sixteen[16], seventeen[17], eighteen[18], nineteen[19].
        Les dizaines sont formées en ajoutant le suffixe -(t)y à la racine du chiffre multiplicateur correspondant, à l’exception de dix : ten[10], twenty[20], thirty[30], forty[40] (et non fourty), fifty[50], sixty[60], seventy[70], eighty[80] et ninety[90].
        De vingt et un à quatre-vingt-dix-neuf, les dizaines et les unités sont jointes par un tiret(exp. : twenty-one[21], fifty-six[56]).
        Pour tous les nombres à trois chiffres, on écrit le nombre de centaines, puis and(et), et enfin les dizaines et les unités(exp. : two hundred and sixty-five[265]). L’utilisation de la coordination and est une question de choix : si certains auteurs la préfèrent, le Chicago Manual of Style préfère quant à lui l’omettre.
        Les mots hundred(cent), thousand(mille) et million(million) sont toujours au singulier(exp. : six hundred and thirty-five[635]).
        Lorsque des unités ou des dizaines s’ajoutent directement à des centaines ou des milliers, on ajoute la conjonction and(et) (exp. : seven hundred and three[703], five thousand and two[5 002]).
        La langue anglaise utilise l’échelle courte pour exprimer les grands nombres : chaque nouveau nom de nombre plus grand que le million est mille fois plus grand que le précédent.Ainsi, on a one billion (un milliard, 109), puis one trillion(un billion, 1012), one quadrillion(un billiard, 1015)…
        */
        public static string NumberToWords_English(int number)
        {
            if ((number > 1000000000) || (number < -1000000000))
                return "ERROR";

            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords_English(Math.Abs(number));

            string words = "";

            //if ((number / 1000000000000) > 0)
            //{
            //    words += NumberToWords_French(number / 1000000000000) + " trillion ";
            //    number %= 1000000000000;
            //}

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords_French(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords_English(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords_English(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords_English(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }
            return words;
        }

        //public static string NumberToWords_French_BAD(int number)
        //{
        //    if (number == 0)
        //        return "zéro";
        //
        //    if (number < 0)
        //        return "moins " + NumberToWords_French(Math.Abs(number));
        //
        //    string words = "";
        //
        //    //if ((number / 1000000000000) > 0)
        //    //{
        //    //    words += NumberToWords_French(number / 1000000000000) + " billiard ";
        //    //    number %= 1000000000000;
        //    //}
        //
        //    if ((number / 1000000000) > 0)
        //    {
        //        words += NumberToWords_French(number / 1000000000) + " milliard ";
        //        number %= 1000000000;
        //    }
        //
        //    if ((number / 1000000) > 0)
        //    {
        //        words += NumberToWords_French(number / 1000000) + " million ";
        //        number %= 1000000;
        //    }
        //
        //    if ((number / 1000) > 0)
        //    {
        //        words += NumberToWords_French(number / 1000) + " mille ";
        //        number %= 1000;
        //    }
        //
        //    if ((number / 100) > 0)
        //    {
        //        words += NumberToWords_French(number / 100) + " cent ";
        //        number %= 100;
        //    }
        //
        //    if (number > 0)
        //    {
        //        if (words != "")
        //            words += "et ";
        //
        //        var unitsMap = new[] { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix sept", "dix huit", "dix neuf" };
        //        var tensMap = new[] { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre vingt", "quatre-vingt-dix" };
        //
        //        if (number < 20)
        //            words += unitsMap[number];
        //        else
        //        {
        //            words += tensMap[number / 10];
        //            //if ((number % 10) > 0)
        //            //    words += "-" + unitsMap[number % 10];
        //        }
        //    }
        //    return words;
        //}

        /*
        Liste de nombres en français :
        1 – un
        2 – deux
        3 – trois
        4 – quatre
        5 – cinq
        6 – six
        7 – sept
        8 – huit
        9 – neuf
        10 – dix
        11 – onze
        12 – douze
        13 – treize
        14 – quatorze
        15 – quinze
        16 – seize
        17 – dix-sept
        18 – dix-huit
        19 – dix-neuf
        20 – vingt
        30 – trente
        40 – quarante
        50 – cinquante
        60 – soixante
        70 – soixante-dix
        80 – quatre-vingts
        90 – quatre-vingt-dix
        100 – cent
        1 000 – mille
        un million – un million
        un milliard – un milliard
        un billion – un billion
        // ***********************************
        Règles de numération en français
        Les chiffres de zéro à neuf sont rendus par des mots spécifiques, de même que les nombres de dix à seize : zéro [0], un (une au féminin) [1], deux [2], trois [3], quatre [4], cinq [5], six [6], sept [7], huit [8], neuf [9], dix [10], onze [11], douze [12], treize [13], quatorze [14], quinze [15] et seize [16]. Les nombres de dix-sept à dix-neuf sont réguliers, c’est-à-dire qu’ils sont formés de la dizaine suivie d’un tiret et de l’unité : dix-sept [10+7], dix-huit [10+8], dix-neuf [10+9].
        Les dizaines sont rendues par des mots spécifiques de dix à soixante : dix [10], vingt [20], trente [30], quarante [40], cinquante [50] et soixante [60].
        De soixante et un à quatre-vingt-dix-neuf, la base 20 est utilisée (ce système vigésimal semble être un héritage des langues celtes), d’où soixante-dix [60+10], soixante-dix-neuf [60+10+9], quatre-vingts [4*20] et quatre-vingt-dix [4*20+10].
        Les dizaines et les unités sont jointes par un tiret (exp. : quarante-six [46]), à moins que l’unité soit un. Dans ce cas, la conjonction de coordination et est placée entre la dizaine et l’unité, figurant une addition (exp. : quarante et un [41]).
        Vingt et cent sont au pluriel lorsqu’ils sont multipliés par un nombre plus grand que un et qu’ils terminent le nombre (exp. : mille deux cents [1 200], mais deux cent quarante-six [246]), ou bien lorsqu’ils sont placés juste avant un nom d’échelle comme million, milliard… (exp. : six cents millions [600 000 000]).
        */
        public static string NumberToWords_French(double chiffre)
        {
            //max int32 = 2147483647
            if ((chiffre > 1000000000) || (chiffre < -1000000000))
                return "ERROR";

            int centaine, dizaine, unite, reste, y;
            bool dix = false;
            bool soixanteDix = false;
            string lettre = "";

            if (chiffre < 0)
            {
                lettre = "moins ";
                chiffre = Math.Abs(chiffre);
            }

            reste = (int)chiffre / 1;



            for (int i = 1000000000; i >= 1; i /= 1000)
            {
                y = reste / i;
                if (y != 0)
                {
                    centaine = y / 100;
                    dizaine = (y - centaine * 100) / 10;
                    unite = y - (centaine * 100) - (dizaine * 10);
                    switch (centaine)
                    {
                        case 0:
                            break;
                        case 1:
                            lettre += "cent ";
                            break;
                        case 2:
                            if ((dizaine == 0) && (unite == 0)) lettre += "deux cents ";
                            else lettre += "deux cent ";
                            break;
                        case 3:
                            if ((dizaine == 0) && (unite == 0)) lettre += "trois cents ";
                            else lettre += "trois cent ";
                            break;
                        case 4:
                            if ((dizaine == 0) && (unite == 0)) lettre += "quatre cents ";
                            else lettre += "quatre cent ";
                            break;
                        case 5:
                            if ((dizaine == 0) && (unite == 0)) lettre += "cinq cents ";
                            else lettre += "cinq cent ";
                            break;
                        case 6:
                            if ((dizaine == 0) && (unite == 0)) lettre += "six cents ";
                            else lettre += "six cent ";
                            break;
                        case 7:
                            if ((dizaine == 0) && (unite == 0)) lettre += "sept cents ";
                            else lettre += "sept cent ";
                            break;
                        case 8:
                            if ((dizaine == 0) && (unite == 0)) lettre += "huit cents ";
                            else lettre += "huit cent ";
                            break;
                        case 9:
                            if ((dizaine == 0) && (unite == 0)) lettre += "neuf cents ";
                            else lettre += "neuf cent ";
                            break;
                    }// endSwitch(centaine)

                    switch (dizaine)
                    {
                        case 0:
                            break;
                        case 1:
                            dix = true;
                            break;
                        case 2:
                            lettre += "vingt ";
                            break;
                        case 3:
                            lettre += "trente ";
                            break;
                        case 4:
                            lettre += "quarante ";
                            break;
                        case 5:
                            lettre += "cinquante ";
                            break;
                        case 6:
                            lettre += "soixante ";
                            break;
                        case 7:
                            dix = true;
                            soixanteDix = true;
                            lettre += "soixante ";
                            break;
                        case 8:
                            lettre += "quatre-vingt ";
                            break;
                        case 9:
                            dix = true;
                            lettre += "quatre-vingt ";
                            break;
                    } // endSwitch(dizaine)

                    switch (unite)
                    {
                        case 0:
                            if (dix) lettre += "dix ";
                            break;
                        case 1:
                            if (soixanteDix) lettre += "et onze ";
                            else
                                if (dix) lettre += "onze ";
                            else if ((dizaine != 1 && dizaine != 0)) lettre += "et un ";
                            else lettre += "un ";
                            break;
                        case 2:
                            if (dix) lettre += "douze ";
                            else lettre += "deux ";
                            break;
                        case 3:
                            if (dix) lettre += "treize ";
                            else lettre += "trois ";
                            break;
                        case 4:
                            if (dix) lettre += "quatorze ";
                            else lettre += "quatre ";
                            break;
                        case 5:
                            if (dix) lettre += "quinze ";
                            else lettre += "cinq ";
                            break;
                        case 6:
                            if (dix) lettre += "seize ";
                            else lettre += "six ";
                            break;
                        case 7:
                            if (dix) lettre += "dix-sept ";
                            else lettre += "sept ";
                            break;
                        case 8:
                            if (dix) lettre += "dix-huit ";
                            else lettre += "huit ";
                            break;
                        case 9:
                            if (dix) lettre += "dix-neuf ";
                            else lettre += "neuf ";
                            break;
                    } // endSwitch(unite)

                    switch (i)
                    {
                        case 1000000000:
                            if (y > 1) lettre += "milliards ";
                            else lettre += "milliard ";
                            break;
                        case 1000000:
                            if (y > 1) lettre += "millions ";
                            else lettre += "million ";
                            break;
                        case 1000:
                            lettre += "mille ";
                            break;
                    }
                } // end if(y!=0)
                reste -= y * i;
                dix = false;
                soixanteDix = false;
            } // end for
            if (lettre.Length == 0) lettre += "zero";

            // pour les chiffres apres la virgule :
            Decimal chiffre3;
            chiffre3 = (Decimal)(chiffre * 100) % 100;
            Console.WriteLine(chiffre3);

            //int chiffre2 = (int)((chiffre - (int)(chiffre/1))*100);
            //Console.WriteLine(chiffre2);
            dizaine = (int)(chiffre3) / 10;
            unite = (int)chiffre3 - (dizaine * 10);

            string lettre2 = "";
            switch (dizaine)
            {
                case 0:
                    break;
                case 1:
                    dix = true;
                    break;
                case 2:
                    lettre2 += "vingt ";
                    break;
                case 3:
                    lettre2 += "trente ";
                    break;
                case 4:
                    lettre2 += "quarante ";
                    break;
                case 5:
                    lettre2 += "cinquante ";
                    break;
                case 6:
                    lettre2 += "soixante ";
                    break;
                case 7:
                    dix = true;
                    soixanteDix = true;
                    lettre2 += "soixante ";
                    break;
                case 8:
                    lettre2 += "quatre-vingt ";
                    break;
                case 9:
                    dix = true;
                    lettre2 += "quatre-vingt ";
                    break;
            } // endSwitch(dizaine)

            switch (unite)
            {
                case 0:
                    if (dix) lettre2 += "dix ";
                    break;
                case 1:
                    if (soixanteDix) lettre2 += "et onze ";
                    else
                        if (dix) lettre2 += "onze ";
                    else if ((dizaine != 1 && dizaine != 0)) lettre2 += "et un ";
                    else lettre2 += "un ";
                    break;
                case 2:
                    if (dix) lettre2 += "douze ";
                    else lettre2 += "deux ";
                    break;
                case 3:
                    if (dix) lettre2 += "treize ";
                    else lettre2 += "trois ";
                    break;
                case 4:
                    if (dix) lettre2 += "quatorze ";
                    else lettre2 += "quatre ";
                    break;
                case 5:
                    if (dix) lettre2 += "quinze ";
                    else lettre2 += "cinq ";
                    break;
                case 6:
                    if (dix) lettre2 += "seize ";
                    else lettre2 += "six ";
                    break;
                case 7:
                    if (dix) lettre2 += "dix-sept ";
                    else lettre2 += "sept ";
                    break;
                case 8:
                    if (dix) lettre2 += "dix-huit ";
                    else lettre2 += "huit ";
                    break;
                case 9:
                    if (dix) lettre2 += "dix-neuf ";
                    else lettre2 += "neuf ";
                    break;
            }

            // on enleve le un devant le mille :
            if (lettre.StartsWith("un mille"))
            {
                //Console.WriteLine("on enleve le un devant le mille");
                lettre = lettre.Remove(0, 3);
            }

            //return lettre;

            //if (lettre2.Equals(""))
            //    return lettre + "euro";
            //else if (dizaine.Equals(0) && unite.Equals(1))
            //    return lettre + "euro et " + lettre2 + "centime";
            //else
            //    return lettre + "euro et " + lettre2 + "centimes";

            //if (dizaine.Equals(0) && unite.Equals(1))
            if(lettre2 != "")
                return lettre + " virgule " + lettre2;
            else
                return lettre;
        }

        /*
        1 – uno
        2 – dos
        3 – tres
        4 – cuatro
        5 – cinco
        6 – seis
        7 – siete
        8 – ocho
        9 – nueve
        10 – diez
        11 – once
        12 – doce
        13 – trece
        14 – catorce
        15 – quince
        16 – dieciséis
        17 – diecisiete
        18 – dieciocho
        19 – diecinueve
        20 – veinte
        30 – treinta
        40 – cuarenta
        50 – cincuenta
        60 – sesenta
        70 – setenta
        80 – ochenta
        90 – noventa
        100 – cien
        1 000 – mil
        un million – un millón
        un milliard – mil millones
        un billion – un billón
        // ***********************************
        Règles de numération en espagnol :
        Les chiffres de zéro à neuf et les nombres de dix à quinze sont rendus par des mots spécifiques : cero [0], uno [1] (qui s’apocope en un devant une voyelle, et possède une forme féminine : una), dos [2], tres [3], cuatro [4], cinco [5], seis [6], siete [7], ocho [8], nueve [9], diez [10], once [11], doce [12], trece [13], catorce [14], quince [15]. Les nombres de seize à vingt-neuf sont réguliers, c’est-à-dire construits d’après la dizaine et l’unité. Diez y seis [10 et 6] s’apocope en dieciséis. La même chose s’applique jusqu’à vingt-neuf : diecisiete [10 et 7], dieciocho [10 et 8]… veintinueve [20 et 9].
        Les dizaines ont des noms spécifiques basés sur la racine de leur chiffre multiplicateur correspondant, à l’exception de dix et vingt : diez [10], veinte [20], treinta [30], cuarenta [40], cincuenta [50], sesenta [60], setenta [70], ochenta [80] et noventa [90].
        La même règle s’applique aux centaines dont le nom se crée en supprimant l’espace entre le coefficient multiplicateur et le mot cent : cien [100] (cientos au pluriel), mais doscientos [200], trescientos [300], cuatrocientos [400], quinientos [500], seiscientos [600], setecientos [700], ochocientos [800] et novecientos [900].
        Les dizaines et les unités sont reliées par y (et), comme dans treinta y cinco [35].
        Le mot pour mille est mil. Les milliers se forment en mettant le chiffre multiplicateur devant celui-ci, séparé par un espace, à l’exception de mille lui-même : mil [1 000], dos mil [2 000], tres mil [3 000], cuatro mil [4 000], cinco mil [5 000]…
        L’espagnol utilise l’échelle longue pour nommer les grands nombres : chaque nouveau nom de nombre plus grand que le million est un million de fois plus grand que le précédent. Le mot pour million est millón (et millones au pluriel), puis nous avons mil millones (109, un milliard), un billón (1012, un billion), mil billones (1015, un billiard), un trillón (1018, un trillion)… La seule exception (locale) à cette règle se trouve dans l’espagnol pratiqué à Porto Rico où l’échelle courte est en usage. Ainsi, à Porto Rico, un billón vaut 109, soit un milliard.
        */
        public static string NumberToWords_Spanish(double number)
        {
            return "Spanish To Do";
        }

        /*
        1 – uno
        2 – due
        3 – tre
        4 – quattro
        5 – cinque
        6 – sei
        7 – sette
        8 – otto
        9 – nove
        10 – dieci
        11 – undici
        12 – dodici
        13 – tredici
        14 – quattordici
        15 – quindici
        16 – sedici
        17 – diciassette
        18 – diciotto
        19 – diciannove
        20 – venti
        30 – trenta
        40 – quaranta
        50 – cinquanta
        60 – sessanta
        70 – settanta
        80 – ottanta
        90 – novanta
        100 – cento
        1 000 – mille
        un million – un milione
        un milliard – un miliardo
        un billion – un bilione
        // ***********************************
        Règles de numération en italien :
        Les nombres de zéro à dix sont rendus par des mots spécifiques : zero [0], uno [1], due [2], tre [3], quattro [4], cinque [5], sei [6], sette [7], otto [8], nove [9] et dieci [10].
        De onze à seize, les nombres sont formés à partir de la racine du chiffre suivie de dix : undici [11], dodici [12], tredici [13], quattordici [14], quindici [15] et sedici [16]. De dix-sept à dix-neuf, l’ordre est inversé, l’unité étant placée après dix : diciassette [17], diciotto [18] et diciannove [19].
        Les dizaines sont rendues par des mots spécifiques basés sur la racine du chiffre correspondant, à l’exception de dix et vingt : dieci [10], venti [20], trenta [30], quaranta [40], cinquanta [50], sessanta [60], settanta [70], ottanta [80] et novanta [90].
        Les nombres composés sont formés en juxtaposant la dizaine et l’unité, provoquant l’apocope de la dernière voyelle de la dizaine devant un chiffre commençant par une voyelle, c’est-à-dire un et huit (exp. : ventuno [21], trentadue [32], quarantotto [48]). Lorsqu’un nombre composé se termine par trois, tre se transforme en tré et l’accent se porte sur la dernière syllabe (exp. : cinquantatré [53]).
        Les centaines sont formées en préfixant le mot cent par le chiffre multiplicateur, à l’exception de cent lui-même : cento [100], duecento [200], trecento [300], quattrocento [400]…
        Les centaines, dizaines et unités sont accolées sans espace et forment un seul mot (exp. : centonove [109], duecentotrenta [230], novecentonovantanove [999]).
        Les milliers sont formés en préfixant le mot mille par le chiffre multiplicateur, à l’exception de mille lui-même : mille [1 000] (mila au pluriel), duemila [2 000], tremila [3 000], quattromila [4 000], cinquemila [5 000]…
        Les nombres sont groupés en mots de trois chiffres, avec la règle spécifique qui veut qu’un espace soit ajouté après le mot mille si son multiplicateur est plus grand que cent mais ne se termine pas par deux zéros (exp. : duemilatrecentoquarantacinque [2 345], seicentomiladue [600 002], settecentosessantacinquemila duecento [765 200]).
        Tout comme le français, l’italien utilise l’échelle longue pour exprimer les grands nombres : chaque nouveau nom de nombre plus grand que le million est un million de fois plus grand que le précédent. Un million est un milione, un milliard, un miliardo, et un billion (1012), un bilione.
        Il est à noter que le chiffre un (uno) se transforme en un devant un mot masculin, ce qui est le cas de tous les noms d’échelle. Par ailleurs, leur pluriel est régulier, le -e et le -o final se transformant en -i (exp : un milione [un million], due milioni [deux millions], un miliardo [un milliard], due miliardi [deux milliards]).
        */
        public static string NumberToWords_Italian(double number)
        {
            return "Italian To Do";
        }

        /*
        1 – um
        2 – dois
        3 – três
        4 – quatro
        5 – cinco
        6 – seis
        7 – sete
        8 – oito
        9 – nove
        10 – dez
        11 – onze
        12 – doze
        13 – treze
        14 – catorze
        15 – quinze
        16 – dezasseis
        17 – dezassete
        18 – dezoito
        19 – dezanove
        20 – vinte
        30 – trinta
        40 – quarenta
        50 – cinquenta
        60 – sessenta
        70 – setenta
        80 – oitenta
        90 – noventa
        100 – cem
        1 000 – mil
        un million – um milhão
        un milliard – mil milhões
        un billion – um bilião
        // ***********************************
        Règles de numération en portugais (Portugal)
        Les chiffres de zéro à neuf et les nombres de dix à quinze sont rendus par des mots spécifiques : zero [0], um [1], dois [2], três [3], quatro [4], cinco [5], seis [6], sete [7], oito [8], nove [9], dez [10], onze [11], doze [12], treze [13], catorze [14], quinze [15]. Les nombres de seize à dix-neuf sont réguliers, c’est-à-dire construits d’après la dizaine et l’unité, et écrits phonétiquement : dezasseis [10 et 6], dezassete [10 et 7], dezoito [10 et 8], dezanove [10 et 9].
        Les dizaines ont des noms spécifiques basés sur la racine des chiffres correspondants, à l’exception de dix et vingt : dez [10], vinte [20], trinta [30], quarenta [40], cinquenta [50], sessenta [60], setenta [70], oitenta [80] et noventa [90].
        La même règle s’applique aux centaines : cem [100] (centos au pluriel), duzentos [200], trezentos [300], quatrocentos [400], quinhentos [500], seiscentos [600], setecentos [700], oitocentos [800], novecentos [900].
        Les dizaines et les unités sont reliées par e (et), comme dans trinta e cinco [35], de même que les centaines et les dizaines (exp. : cento e quarenta e seis [146]), mais pas les milliers et les centaines, à moins que le nombre se termine par une centaine avec deux zéros (exp. : dois mil e trezentos [2 300] mais dois mil trezentos e sete [2 307]). E s’utilise aussi pour lier directement les milliers et les unités (exp. : quatro mil e cinco [4 005]).
        Le portugais européen utilise l’échelle longue où chaque nouveau nom de nombre plus grand que le million est un million de fois plus grand que le précédent (tandis que le Brésil utilise l’échelle courte où le facteur un million est remplacé par un facteur mille). Par exemple, um milhão vaut un million (106), puis viennent mil milhões (un milliard, 109), um bilião (un billion, 1012), mil biliões (un billiard, 1015), um trilião (un trillion, 1018), mil triliões (un trilliard, 1021)…
         */
        public static string NumberToWords_Portuguese(double number)
        {
            return "Portuguese To Do";
        }

        /*
        Liste de nombres en allemand :
        1 – eins
        2 – zwei
        3 – drei
        4 – vier
        5 – fünf
        6 – sechs
        7 – sieben
        8 – acht
        9 – neun
        10 – zehn
        11 – elf
        12 – zwölf
        13 – dreizehn
        14 – vierzehn
        15 – fünfzehn
        16 – sechzehn
        17 – siebzehn
        18 – achtzehn
        19 – neunzehn
        20 – zwanzig
        30 – dreißig
        40 – vierzig
        50 – fünfzig
        60 – sechzig
        70 – siebzig
        80 – achtzig
        90 – neunzig
        100 – hundert
        1 000 – tausend
        un million – eine Million
        un milliard – eine Milliarde
        un billion – eine Billion
        // ***********************************
        Règles de numération en allemand :
        Les chiffres de zéro à neuf et les nombres de dix à douze sont rendus par des mots spécifiques : null [0], eins [1], zwei [2], drei [3], vier [4], fünf [5], sechs [6], sieben [7], acht [8], neun [9], zehn [10], elf [11] et zwölf [12].
        De treize à dix-neuf, les nombres sont formés à partir des chiffres de trois à neuf auxquels on ajoute le suffixe -zehn (dix) : dreizehn [13], vierzehn [14], fünfzehn [15], sechzehn [16], siebzehn (et non siebenzehn) [17], achtzehn [18] et neunzehn [19].
        Les dizaines se forment en ajoutant le suffixe -zig à la racine du chiffre multiplicateur correspondant, à l’exception de dix, vingt, soixante-dix (encore irrégulier), ainsi que de trente : zehn [10], zwanzig [20], dreißig [30] (-zig se transforme en -ßig), vierzig [40], fünfzig [50], sechzig [60], siebzig [70], achtzig [80] et neunzig [90].
        De vingt et un à quatre-vingt-dix-neuf, les dizaines et les unités sont jointes par la conjonction und (et), mais l’unité se place avant la dizaine (exp. : einunddreißig [31], fünfunddreißig [35]).
        Cent (hundert) et mille (tausend) ne sont pas séparés des autres nombres par un espace (exp. : hunderteinundzwanzig [121], tausendzweihundertneunzehn [1 219]).
        Lorsqu’ils expriment une année, les nombres de 1 100 à 1 999 se disent, comme parfois en français, en dizaines de centaines. Par exemple, 1985 se dira neunzehnhundertfünfundachtzig (soit dix-neuf cent quatre-vingt-cinq).
        Le chiffre un (eins) perd son -s final lorsqu’il est composé dans un nombre, à moins qu’il ne soit l’unique valeur après un nom d’échelle (exp. : hunderteins [101], tausendeins [1 001]).
        La langue allemande utilise l’échelle longue pour exprimer les grands nombres : chaque nouveau nom de nombre plus grand que le million est un million de fois plus grand que le précédent. Ainsi, eine Milliarde vaut 109 (un milliard), et eine Billion (1012), un billion.
        */
        public static string NumberToWords_German(double number)
        {
            return "German To Do";
        }

        // *************************************************
        public static void Test()
        {
            List<string> lesNombres = new List<string>();
            lesNombres.Add(3210987654321.2.ToLettersFrench());
            lesNombres.Add(123456789012345.123456789.ToLettersFrench());    //ce nombre n'existe pas en double, c'est 123456789012345.12 qui est transmis à la méthode
            lesNombres.Add(1234.123456789.ToLettersFrench());
            lesNombres.Add((-4321.987654321).ToLettersFrench());
            lesNombres.Add(1e16.ToLettersFrench());                         //ce nombre est trop grand
            lesNombres.Add(0.12345678961.ToLettersFrench());                //il y a trop de chiffres dérrière la virgule, le resultat sera arrondi
            lesNombres.Add(6795432.456.ToLettersFrench(Pays.Belgique, Devise.Euro));
            lesNombres.Add(400400400400400.0.ToLettersFrench());
            lesNombres.Add(0.4.ToLettersFrench());
            return;
        }

        #region NumberToLettres
        //public static class NombreEnLettres
        //{
            private static string[] jusqueSeize = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize" };
            private static string[] dizaines = { "rien", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante", "quatre-vingt", "quatre-vingt" };

            private static List<string> resultat;

            /// <summary>
            /// Méthode d'extension de la classe double écrivant le nombre en lettres
            /// </summary>
            /// <param name="Nombre">Nombre à écrire</param>
            /// <param name="LePays">Pays d'utilisation, pour spécificitées régionnales</param>
            /// <param name="LaDevise">Devise à utliser</param>
            /// <returns></returns>
            public static string ToLettersFrench(this double Nombre, Pays LePays = Pays.France, Devise LaDevise = Devise.Aucune)
            {

                resultat = new List<string>();

                switch (Math.Sign(Nombre))
                {
                    case -1:
                        resultat.Add("moins ");
                        Nombre *= -1;
                        break;

                    case 0:
                        return jusqueSeize[0];
                }

                if (Nombre >= 1e16)
                    return "Nombre trop grand";


                Int64 partieEntiere = (Int64)(Nombre);
                double partieDecimale = Nombre - partieEntiere;

                string[] milliers = { "", "mille", "million", "milliard", "billion", "billiard" };

                if (partieEntiere > 0)
                {
                    List<int> troisChiffres = new List<int>();//liste qui scinde la partie entière en morceaux de 3 chiffres

                    while (partieEntiere > 0)
                    {
                        troisChiffres.Add((int)(partieEntiere % 1000));
                        partieEntiere /= 1000;
                    }

                    double reste = Nombre - partieEntiere;

                    for (int i = troisChiffres.Count - 1; i >= 0; i--)
                    {
                        int nombre = troisChiffres[i];

                        if (nombre > 1)//valeurs de milliers au pluriel
                        {
                            resultat.Add(Ecrit3Chiffres(troisChiffres[i], LePays, i == 0));
                            if (i > 1)// mille est invariable et "" ne prend pas de s 
                                resultat.Add(milliers[i] + "s");
                            else if (i == 1)
                                resultat.Add(milliers[i]);
                        }
                        else if (nombre == 1)
                        {
                            if (i != 1) resultat.Add("un");//on dit un million, mais pas un mille
                            resultat.Add(milliers[i]);
                        }
                        //on ne traite pas le 0, car on ne dit pas X millions zéro mille Y.
                    }
                }
                else
                    resultat.Add(jusqueSeize[0]);

                switch (LaDevise)
                {
                    case Devise.Dollar:
                        resultat.Add("$");
                        break;

                    case Devise.Euro:
                        resultat.Add("€");
                        break;

                    case Devise.FrancSuisse:
                        resultat.Add("CHF");
                        break;
                }

                if (LaDevise != Devise.Aucune)
                {
                    partieDecimale = Math.Round(partieDecimale, 2);
                    if (partieDecimale != 0)
                    {
                        resultat.Add("et");
                        resultat.Add(Ecrire2Chiffres((int)(partieDecimale * 100), LePays));
                        resultat.Add("centimes");
                    }
                }
                else
                {
                    milliers = new[] { "millième", "millionième", "milliardième" };
                    //avec l'imprécision des nombres à virgules flotantes,  1234562.789 - 1234562 donne 0.78900000010617077 il faut donc compter le nombre de chiffres décimaux du nombre original et arrondir le resultat de la soustraction 
                    string[] morceaux = Nombre.ToString("G25").Split(new[] { '.', ',' });//par défaut ToString arrondi à 10^-8, le format G25 oblige à écrire 25 caractères s'ils sont présents soit (au pire) 15 avant la virgule, la virgule et 9 après, split permet de découper le string obtenu

                    if (morceaux.Length == 2)//il y a une partie décimale
                    {
                        resultat.Add("et");

                        int lenghtPartieDecimale = morceaux[1].Length;
                        if (lenghtPartieDecimale > 9)
                            lenghtPartieDecimale = 9; //on se limite à 10^-9

                        partieDecimale = Math.Round(partieDecimale, lenghtPartieDecimale);

                        int i = 0;
                        while (partieDecimale > 0)
                        {
                            partieDecimale = partieDecimale * 1000;
                            int valeur = (int)partieDecimale;
                            lenghtPartieDecimale -= 3;
                            if (lenghtPartieDecimale < 0)
                                lenghtPartieDecimale = 0;
                            partieDecimale = Math.Round(partieDecimale - valeur, lenghtPartieDecimale);

                            if (valeur != 0)
                            {
                                resultat.Add(Ecrit3Chiffres(valeur, LePays, false));
                                if (valeur > 1)
                                    resultat.Add(milliers[i++] + "s");
                                else
                                    resultat.Add(milliers[i++]);
                            }
                        }
                    }
                }

                return string.Join(" ", resultat);
            }

            /// <summary>
            /// Ecrit les nombres de 0 à 999
            /// </summary>
            /// <param name="Nombre">Nombre à écrire</param>
            /// <param name="LePays">Pays d'utilisation, pour spécificitées régionnales</param>
            /// <param name="RegleDuCent">pour 400 cent prend un s alors que pour 400 000 ou 0.400 non </param>
            private static string Ecrit3Chiffres(int Nombre, Pays LePays, bool RegleDuCent)
            {
                if (Nombre == 100)
                    return "cent";

                if (Nombre < 100)
                    return Ecrire2Chiffres(Nombre, LePays);

                int centaine = Nombre / 100;
                int reste = Nombre % 100;

                if (reste == 0)
                    if (RegleDuCent)//Cent prend un s quand il est multiplié et non suivi d'un nombre, comme le cas de 100 est déjà traité on est face à un multiple
                        return jusqueSeize[centaine] + " cents";
                    else
                        return jusqueSeize[centaine] + " cent"; // par contre s'il est suivi de mille, millions, millièmes etc... pas de s

                if (centaine == 1)
                    return "cent " + Ecrire2Chiffres(reste, LePays);    //on ne dit pas un cent X, mais cent X

                return jusqueSeize[centaine] + " cent " + Ecrire2Chiffres(reste, LePays);
            }

            /// <summary>
            /// Ecrit les nombres de 0 à 99
            /// </summary>
            /// <param name="Nombre">Nombre à écrire</param>
            /// <param name="LePays">Pays d'utilisation, pour spécificitées régionnales</param>
            /// <returns></returns>
            private static string Ecrire2Chiffres(int Nombre, Pays LePays)
            {
                if (LePays != Pays.France)
                {
                    dizaines[7] = "septante";
                    dizaines[9] = "nonante";
                }
                if (LePays == Pays.Suisse)
                    dizaines[8] = "huitante";

                if (Nombre < 17)
                    return jusqueSeize[Nombre];

                switch (Nombre)//cas particuliers de 71, 80 et 81
                {
                    case 71:    //en France 71 prend un et
                        if (LePays == Pays.France)
                            return "soixante et onze";
                        break;

                    case 80:    //en France et Belgique le vingt prend un s
                        if (LePays == Pays.Suisse)
                            return dizaines[8];
                        else
                            return dizaines[8] + "s";

                    case 81:    //en France et Belgique il n'y a pas de et
                        if (LePays != Pays.Suisse)
                            return dizaines[8] + "-un";
                        break;
                }

                int dizaine = Nombre / 10;
                int unite = Nombre % 10;

                string laDizaine = dizaines[dizaine];

                if (LePays == Pays.France && (dizaine == 7 || dizaine == 9))
                {
                    dizaine--;
                    unite += 10;
                }


                switch (unite)
                {
                    case 0:
                        return laDizaine;

                    case 1:
                        return laDizaine + " et un";

                    case 17:    //pour 77 à 79 et 97 à 99
                    case 18:
                    case 19:
                        unite = unite % 10;
                        return laDizaine + "-dix-" + jusqueSeize[unite];

                    default:
                        return laDizaine + "-" + jusqueSeize[unite];
                }
            }
        }

        public enum Pays
        {
            France,
            Belgique,
            Suisse
        }

        public enum Devise
        {
            Aucune,
            Euro,
            FrancSuisse,
            Dollar
        }
    
    #endregion
    //}
}
