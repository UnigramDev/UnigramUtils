using System;
using System.Collections.Generic;
using System.Text;

namespace FontFactory
{
    class C0914b
    {
        /* renamed from: a */
        public string f24111a;
        /* renamed from: b */
        public int f24112b;

        public C0914b(string charSequence)
        {
            this.f24111a = charSequence;
        }

        public int next()
        {
            while (this.f24112b < this.f24111a.Length)
            {
                //int codePointAt = Character.codePointAt(this.f24111a, this.f24112b);
                int codePointAt = char.IsSurrogatePair(this.f24111a, this.f24112b) ? char.ConvertToUtf32(this.f24111a, this.f24112b) : this.f24111a[this.f24112b];
                this.f24112b = CharCount(codePointAt) + this.f24112b;
                if (codePointAt != 65039)
                {
                    if (codePointAt != 65038)
                    {
                        //if (C2092e.f7952a)
                        //{
                        //    int i = 65536 | codePointAt;
                        //    if (m5160a(i))
                        //    {
                        //        codePointAt = i;
                        //    }
                        //}
                        return codePointAt;
                    }
                }
            }
            return 0;
        }

        public static int CharCount(int codePoint)
        {
            return codePoint >= 0x10000 ? 2 : 1;
        }

        public bool m5160a(int i)
        {
            return i >= 126980 && i <= 129535;
        }
    }

    class Test
    {
        public static int getDescriptor(C0914b c0914b)
        {
            int next = c0914b.next();
            if (next == 8617)
            {
                return 16779586;
            }
            if (next == 8618)
            {
                return 16779587;
            }
            if (next == 8986)
            {
                return 16779588;
            }
            if (next == 8987)
            {
                return 16779589;
            }
            if (next == 9642)
            {
                return 16779607;
            }
            if (next == 9643)
            {
                return 16779608;
            }
            if (next == 9748)
            {
                return 16779622;
            }
            if (next == 9749)
            {
                return 16779623;
            }
            int i = 16778165;
            int i2 = -1;
            int next2;
            int next3;
            switch (next)
            {
                case 35:
                    next2 = c0914b.next();
                    if (next2 == 8419)
                    {
                        return 33554432;
                    }
                    if (next2 != 65039)
                    {
                        return -1;
                    }
                    if (c0914b.next() == 8419)
                    {
                        i2 = 50331648;
                    }
                    return i2;
                case 42:
                    next2 = c0914b.next();
                    if (next2 == 8419)
                    {
                        return 33554433;
                    }
                    if (next2 != 65039)
                    {
                        return -1;
                    }
                    if (c0914b.next() == 8419)
                    {
                        i2 = 50331649;
                    }
                    return i2;
                case 169:
                    return 16777228;
                case 174:
                    return 16777229;
                case 8252:
                    return 16779576;
                case 8265:
                    return 16779577;
                case 8482:
                    return 16779578;
                case 8505:
                    return 16779579;
                case 9000:
                    return 16779590;
                case 9167:
                    return 16779591;
                case 9193:
                    return 16779592;
                case 9194:
                    return 16779593;
                case 9195:
                    return 16779594;
                case 9196:
                    return 16779595;
                case 9197:
                    return 16779596;
                case 9198:
                    return 16779597;
                case 9199:
                    return 16779598;
                case 9200:
                    return 16779599;
                case 9201:
                    return 16779600;
                case 9202:
                    return 16779601;
                case 9203:
                    return 16779602;
                case 9410:
                    return 16779606;
                case 9654:
                    return 16779609;
                case 9664:
                    return 16779610;
                case 9742:
                    return 16779620;
                case 9745:
                    return 16779621;
                case 9752:
                    return 16779624;
                case 9757:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556841;
                        case 127996:
                            return 33556842;
                        case 127997:
                            return 33556843;
                        case 127998:
                            return 33556844;
                        case 127999:
                            return 33556845;
                        default:
                            return 16779630;
                    }
                case 9760:
                    return 16779631;
                case 9762:
                    return 16779632;
                case 9763:
                    return 16779633;
                case 9766:
                    return 16779634;
                case 9770:
                    return 16779635;
                case 9774:
                    return 16779636;
                case 9775:
                    return 16779637;
                case 9784:
                    return 16779638;
                case 9785:
                    return 16779639;
                case 9786:
                    return 16779640;
                case 9792:
                    return 16779641;
                case 9794:
                    return 16779642;
                case 9800:
                    return 16779643;
                case 9801:
                    return 16779644;
                case 9802:
                    return 16779645;
                case 9803:
                    return 16779646;
                case 9804:
                    return 16779647;
                case 9805:
                    return 16779648;
                case 9806:
                    return 16779649;
                case 9807:
                    return 16779650;
                case 9808:
                    return 16779651;
                case 9809:
                    return 16779652;
                case 9810:
                    return 16779653;
                case 9811:
                    return 16779654;
                case 9823:
                    return 16779655;
                case 9824:
                    return 16779656;
                case 9827:
                    return 16779657;
                case 9829:
                    return 16779658;
                case 9830:
                    return 16779659;
                case 9832:
                    return 16779660;
                case 9851:
                    return 16779661;
                case 9854:
                    return 16779662;
                case 9855:
                    return 16779663;
                case 9874:
                    return 16779664;
                case 9875:
                    return 16779665;
                case 9876:
                    return 16779666;
                case 9877:
                    return 16779667;
                case 9878:
                    return 16779668;
                case 9879:
                    return 16779669;
                case 9881:
                    return 16779670;
                case 9883:
                    return 16779671;
                case 9884:
                    return 16779672;
                case 9888:
                    return 16779673;
                case 9889:
                    return 16779674;
                case 9895:
                    return 16779675;
                case 9898:
                    return 16779676;
                case 9899:
                    return 16779677;
                case 9904:
                    return 16779678;
                case 9905:
                    return 16779679;
                case 9917:
                    return 16779680;
                case 9918:
                    return 16779681;
                case 9924:
                    return 16779682;
                case 9925:
                    return 16779683;
                case 9928:
                    return 16779684;
                case 9934:
                    return 16779685;
                case 9935:
                    return 16779686;
                case 9937:
                    return 16779687;
                case 9939:
                    return 16779688;
                case 9940:
                    return 16779689;
                case 9961:
                    return 16779690;
                case 9962:
                    return 16779691;
                case 9968:
                    return 16779692;
                case 9969:
                    return 16779693;
                case 9970:
                    return 16779694;
                case 9971:
                    return 16779695;
                case 9972:
                    return 16779696;
                case 9973:
                    return 16779697;
                case 9975:
                    return 16779698;
                case 9976:
                    return 16779699;
                case 9977:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556917;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556917 : 67111349;
                                }
                                else
                                {
                                    return 67111348;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556919;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556919 : 67111351;
                                }
                                else
                                {
                                    return 67111350;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556921;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556921 : 67111353;
                                }
                                else
                                {
                                    return 67111352;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556923;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556923 : 67111355;
                                }
                                else
                                {
                                    return 67111354;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556925;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556925 : 67111357;
                                }
                                else
                                {
                                    return 67111356;
                                }
                            default:
                                return 16779712;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779712 : 50334143;
                    }
                    else
                    {
                        return 50334142;
                    }
                case 9978:
                    return 16779713;
                case 9981:
                    return 16779714;
                case 9986:
                    return 16779715;
                case 9989:
                    return 16779716;
                case 9992:
                    return 16779717;
                case 9993:
                    return 16779718;
                case 9994:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556935;
                        case 127996:
                            return 33556936;
                        case 127997:
                            return 33556937;
                        case 127998:
                            return 33556938;
                        case 127999:
                            return 33556939;
                        default:
                            return 16779724;
                    }
                case 9995:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556941;
                        case 127996:
                            return 33556942;
                        case 127997:
                            return 33556943;
                        case 127998:
                            return 33556944;
                        case 127999:
                            return 33556945;
                        default:
                            return 16779730;
                    }
                case 9996:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556947;
                        case 127996:
                            return 33556948;
                        case 127997:
                            return 33556949;
                        case 127998:
                            return 33556950;
                        case 127999:
                            return 33556951;
                        default:
                            return 16779736;
                    }
                case 9997:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556953;
                        case 127996:
                            return 33556954;
                        case 127997:
                            return 33556955;
                        case 127998:
                            return 33556956;
                        case 127999:
                            return 33556957;
                        default:
                            return 16779742;
                    }
                case 9999:
                    return 16779743;
                case 10002:
                    return 16779744;
                case 10004:
                    return 16779745;
                case 10006:
                    return 16779746;
                case 10013:
                    return 16779747;
                case 10017:
                    return 16779748;
                case 10024:
                    return 16779749;
                case 10035:
                    return 16779750;
                case 10036:
                    return 16779751;
                case 10052:
                    return 16779752;
                case 10055:
                    return 16779753;
                case 10060:
                    return 16779754;
                case 10062:
                    return 16779755;
                case 10067:
                    return 16779756;
                case 10068:
                    return 16779757;
                case 10069:
                    return 16779758;
                case 10071:
                    return 16779759;
                case 10083:
                    return 16779760;
                case 10084:
                    return 16779761;
                case 10133:
                    return 16779762;
                case 10134:
                    return 16779763;
                case 10135:
                    return 16779764;
                case 10145:
                    return 16779765;
                case 10160:
                    return 16779766;
                case 10175:
                    return 16779767;
                case 10548:
                    return 16779768;
                case 10549:
                    return 16779769;
                case 11013:
                    return 16779770;
                case 11014:
                    return 16779771;
                case 11015:
                    return 16779772;
                case 11035:
                    return 16779773;
                case 11036:
                    return 16779774;
                case 11088:
                    return 16779775;
                case 11093:
                    return 16779776;
                case 12336:
                    return 16779777;
                case 12349:
                    return 16779778;
                case 12951:
                    return 16779779;
                case 12953:
                    return 16779780;
                case 57345:
                    return 16778016;
                case 57346:
                    return 16778022;
                case 57347:
                    return 16778483;
                case 57348:
                    return 16778165;
                case 57349:
                    return 16778305;
                case 57350:
                    return 16777994;
                case 57351:
                    return 16778004;
                case 57352:
                    return 16778596;
                case 57353:
                    return 16779620;
                case 57354:
                    return 16778590;
                case 57355:
                    return 16778573;
                case 57356:
                    return 16778536;
                case 57357:
                    return 16777953;
                case 57358:
                    return 16777971;
                case 57359:
                    return 16779630;
                case 57360:
                    return 16779724;
                case 57361:
                    return 16779736;
                case 57362:
                    return 16779730;
                case 57363:
                    return 16777709;
                case 57364:
                    return 16779695;
                case 57365:
                    return 16777708;
                case 57366:
                    return 16779681;
                case 57367:
                    return 16777738;
                case 57368:
                    return 16779680;
                case 57369:
                    return 16777874;
                case 57370:
                    return 16777895;
                case 57371:
                    return 16778955;
                case 57372:
                    return 16779697;
                case 57373:
                    return 16779717;
                case 57374:
                    return 16778935;
                case 57375:
                    return 16778937;
                case 57376:
                    return 16779756;
                case 57377:
                    return 16779759;
                case 57378:
                    return 16779761;
                case 57379:
                    return 16778492;
                case 57380:
                    return 16778672;
                case 57381:
                    return 16778673;
                case 57382:
                    return 16778674;
                case 57383:
                    return 16778675;
                case 57384:
                    return 16778676;
                case 57385:
                    return 16778677;
                case 57386:
                    return 16778678;
                case 57387:
                    return 16778679;
                case 57388:
                    return 16778680;
                case 57389:
                    return 16778681;
                case 57390:
                    return 16778682;
                case 57391:
                    return 16778683;
                case 57392:
                    return 16777574;
                case 57393:
                    return 16778653;
                case 57394:
                    return 16777575;
                case 57395:
                    return 16777650;
                case 57396:
                    return 16778485;
                case 57397:
                    return 16778486;
                case 57398:
                    return 16777807;
                case 57399:
                    return 16779691;
                case 57400:
                    return 16777809;
                case 57401:
                    return 16778941;
                case 57402:
                    return 16779714;
                case 57403:
                    return 16778771;
                case 57404:
                    return 16777682;
                case 57405:
                    return 16777683;
                case 57406:
                    return 16777699;
                case 57407:
                    return 16778621;
                case 57408:
                    return 16777701;
                case 57409:
                    return 16777702;
                case 57410:
                    return 16777704;
                case 57411:
                    return 16777634;
                case 57412:
                    return 16777638;
                case 57413:
                    return 16779623;
                case 57414:
                    return 16777630;
                case 57415:
                    return 16777640;
                case 57416:
                    return 16779682;
                case 57417:
                    return 16779616;
                case 57418:
                    return 16779615;
                case 57419:
                    return 16779622;
                case 57420:
                    return 16777545;
                case 57421:
                    return 16777524;
                case 57422:
                    return 16778414;
                case 57423:
                    return 16777892;
                case 57424:
                    return 16777890;
                case 57425:
                    return 16777902;
                case 57426:
                    return 16777897;
                case 57427:
                    return 16777888;
                case 57428:
                    return 16777894;
                case 57429:
                    return 16777882;
                case 57430:
                    return 16778786;
                case 57431:
                    return 16778779;
                case 57432:
                    return 16778806;
                case 57433:
                    return 16778808;
                case 57434:
                    return 16778513;
                case 57601:
                    return 16778584;
                case 57602:
                    return 16778587;
                case 57603:
                    return 16778582;
                case 57604:
                    return 16778591;
                case 57605:
                    return 16778804;
                case 57606:
                    return 16778789;
                case 57607:
                    return 16778825;
                case 57608:
                    return 16778795;
                case 57609:
                    return 16777896;
                case 57610:
                    return 16777868;
                case 57611:
                    return 16777898;
                case 57612:
                    return 16778415;
                case 57613:
                    return 16778932;
                case 57614:
                    return 16777990;
                case 57615:
                    return 16778505;
                case 57616:
                    return 16777582;
                case 57617:
                    return 16778487;
                case 57618:
                    return 16777647;
                case 57619:
                    return 16778647;
                case 57620:
                    return 16778617;
                case 57621:
                    return 16777725;
                case 57622:
                    return 16778644;
                case 57623:
                    return 16777657;
                case 57624:
                    return 16777583;
                case 57625:
                    return 16777584;
                case 57626:
                    return 16778417;
                case 57627:
                    return 16778408;
                case 57628:
                    return 16778418;
                case 57629:
                    return 16778641;
                case 57630:
                    return 16778537;
                case 57631:
                    return 16778535;
                case 57632:
                    return 16777602;
                case 57633:
                    return 16779694;
                case 57634:
                    return 16779713;
                case 57635:
                    return 16779660;
                case 57636:
                    return 16777679;
                case 57637:
                    return 16777689;
                case 57638:
                    return 16778540;
                case 57639:
                    return 16778541;
                case 57640:
                    return 16778600;
                case 57641:
                    return 16778601;
                case 57642:
                    return 16778599;
                case 57643:
                    return 16778416;
                case 57644:
                    return 16779778;
                case 57645:
                    return 16777230;
                case 57646:
                    return 16777246;
                case 57647:
                    return 16778525;
                case 57648:
                    return 16777693;
                case 57649:
                    return 16777740;
                case 57650:
                    return 16777711;
                case 57651:
                    return 16777694;
                case 57652:
                    return 16777857;
                case 57653:
                    return 16778980;
                case 57654:
                    return 16778994;
                case 57655:
                    return 16778983;
                case 57656:
                    return 16779037;
                case 57657:
                    return 16779038;
                case 57658:
                    return 16779040;
                case 57659:
                    return 16778481;
                case 57660:
                    return 16778508;
                case 57661:
                    return 16779674;
                case 57662:
                    return 16778005;
                case 57663:
                    return 16779049;
                case 57664:
                    return 16779041;
                case 57665:
                    return 16778614;
                case 57666:
                    return 16778575;
                case 57667:
                    return 16777663;
                case 57668:
                    return 16778622;
                case 57669:
                    return 16778623;
                case 57670:
                    return 16777526;
                case 57671:
                    return 16777633;
                case 57672:
                    return 16778563;
                case 57673:
                    return 16778526;
                case 57674:
                    return 16778534;
                case 57675:
                    return 16778574;
                case 57676:
                    return 16778519;
                case 57677:
                    return 16777813;
                case 57678:
                    return 16778981;
                case 57679:
                    return 16777235;
                case 57680:
                    return 16778947;
                case 57681:
                    return 16779039;
                case 57682:
                    return 16778321;
                case 57683:
                    return 16777810;
                case 57684:
                    return 16777814;
                case 57685:
                    return 16777812;
                case 57686:
                    return 16777817;
                case 57687:
                    return 16777818;
                case 57688:
                    return 16777815;
                case 57689:
                    return 16778944;
                case 57690:
                    return 16778953;
                case 57857:
                    return 16779034;
                case 57858:
                    return 16778966;
                case 57859:
                    return 16777505;
                case 57860:
                    return 16778503;
                case 57861:
                    return 16779751;
                case 57862:
                    return 16779750;
                case 57863:
                    return 16778634;
                case 57864:
                    return 16778989;
                case 57865:
                    return 16778652;
                case 57866:
                    return 16779663;
                case 57867:
                    return 16778595;
                case 57868:
                    return 16779658;
                case 57869:
                    return 16779659;
                case 57870:
                    return 16779656;
                case 57871:
                    return 16779657;
                case 57872:
                    return 16777216;
                case 57873:
                    return 16779767;
                case 57874:
                    return 16777241;
                case 57875:
                    return 16777245;
                case 57876:
                    return 16777238;
                case 57877:
                    return 16777513;
                case 57878:
                    return 16777507;
                case 57879:
                    return 16777514;
                case 57880:
                    return 16777515;
                case 57881:
                    return 16778656;
                case 57882:
                    return 16778654;
                case 57883:
                    return 16778655;
                case 57884:
                    return 16777219;
                case 57885:
                    return 16777220;
                case 57886:
                    return 16777221;
                case 57887:
                    return 16777222;
                case 57888:
                    return 16777223;
                case 57889:
                    return 16777224;
                case 57890:
                    return 16777225;
                case 57891:
                    return 16777226;
                case 57892:
                    return 16777227;
                case 57893:
                    return 16777218;
                case 57894:
                    return 16777518;
                case 57895:
                    return 16777516;
                case 57896:
                    return 16777506;
                case 57897:
                    return 16777240;
                case 57898:
                    return 16777512;
                case 57899:
                    return 16777510;
                case 57900:
                    return 16777508;
                case 57901:
                    return 16777517;
                case 57902:
                    return 16777929;
                case 57903:
                    return 16777935;
                case 57904:
                    return 16777941;
                case 57905:
                    return 16777947;
                case 57906:
                    return 16779771;
                case 57907:
                    return 16779772;
                case 57908:
                    return 16779765;
                case 57909:
                    return 16779770;
                case 57910:
                    return 16779583;
                case 57911:
                    return 16779582;
                case 57912:
                    return 16779584;
                case 57913:
                    return 16779585;
                case 57914:
                    return 16779609;
                case 57915:
                    return 16779610;
                case 57916:
                    return 16779592;
                case 57917:
                    return 16779593;
                case 57918:
                    return 16778651;
                case 57919:
                    return 16779643;
                case 57920:
                    return 16779644;
                case 57921:
                    return 16779645;
                case 57922:
                    return 16779646;
                case 57923:
                    return 16779647;
                case 57924:
                    return 16779648;
                case 57925:
                    return 16779649;
                case 57926:
                    return 16779650;
                case 57927:
                    return 16779651;
                case 57928:
                    return 16779652;
                case 57929:
                    return 16779653;
                case 57930:
                    return 16779654;
                case 57931:
                    return 16779685;
                case 57932:
                    return 16778633;
                case 57933:
                    return 16777243;
                case 57934:
                    return 16777228;
                case 57935:
                    return 16777229;
                case 57936:
                    return 16778592;
                case 57937:
                    return 16778593;
                case 57938:
                    return 16779673;
                case 57939:
                    return 16778429;
                case 58113:
                    return 16778570;
                case 58114:
                    return 16777993;
                case 58115:
                    return 16777576;
                case 58116:
                    return 16777573;
                case 58117:
                    return 16777577;
                case 58118:
                    return 16778488;
                case 58119:
                    return 16777570;
                case 58120:
                    return 16777571;
                case 58121:
                    return 16779042;
                case 58122:
                    return 16777685;
                case 58123:
                    return 16777636;
                case 58124:
                    return 16777641;
                case 58125:
                    return 16779779;
                case 58126:
                    return 16778988;
                case 58127:
                    return 16778482;
                case 58128:
                    return 16777659;
                case 58129:
                    return 16778507;
                case 58130:
                    return 16777660;
                case 58131:
                    return 16779715;
                case 58132:
                    return 16777646;
                case 58133:
                    return 16779780;
                case 58134:
                    return 16778538;
                case 58135:
                    return 16778576;
                case 58136:
                    return 16777991;
                case 58137:
                    return 16777996;
                case 58138:
                    return 16778006;
                case 58139:
                    return 16778007;
                case 58140:
                    return 16778449;
                case 58141:
                    return 16778455;
                case 58142:
                    return 16778466;
                case 58143:
                    return 16778478;
                case 58144:
                    return 16778480;
                case 58145:
                    return 16777997;
                case 58146:
                    return 16777998;
                case 58147:
                    return 16778001;
                case 58148:
                    return 16777690;
                case 58149:
                    return 16778624;
                case 58150:
                    return 16777700;
                case 58151:
                    return 16778491;
                case 58152:
                    return 16778495;
                case 58153:
                    return 16778496;
                case 58154:
                    return 16778497;
                case 58155:
                    return 16778498;
                case 58156:
                    return 16778499;
                case 58157:
                    return 16778500;
                case 58158:
                    return 16779749;
                case 58159:
                    return 16779775;
                case 58160:
                    return 16778512;
                case 58161:
                    return 16778510;
                case 58162:
                    return 16779776;
                case 58163:
                    return 16779754;
                case 58164:
                    return 16778506;
                case 58165:
                    return 16777551;
                case 58166:
                    return 16779757;
                case 58167:
                    return 16779758;
                case 58168:
                    return 16777635;
                case 58169:
                    return 16777612;
                case 58170:
                    return 16777620;
                case 58171:
                    return 16777613;
                case 58172:
                    return 16777615;
                case 58173:
                    return 16777606;
                case 58174:
                    return 16777608;
                case 58175:
                    return 16777611;
                case 58176:
                    return 16777610;
                case 58177:
                    return 16777609;
                case 58178:
                    return 16777607;
                case 58179:
                    return 16777616;
                case 58180:
                    return 16777617;
                case 58181:
                    return 16777596;
                case 58182:
                    return 16777592;
                case 58183:
                    return 16777601;
                case 58184:
                    return 16777591;
                case 58185:
                    return 16777587;
                case 58186:
                    return 16777588;
                case 58187:
                    return 16777648;
                case 58188:
                    return 16777631;
                case 58189:
                    return 16777632;
                case 58369:
                    return 16778813;
                case 58370:
                    return 16778791;
                case 58371:
                    return 16778796;
                case 58372:
                    return 16778777;
                case 58373:
                    return 16778785;
                case 58374:
                    return 16778811;
                case 58375:
                    return 16778798;
                case 58376:
                    return 16778818;
                case 58377:
                    return 16778805;
                case 58378:
                    return 16778788;
                case 58379:
                    return 16778816;
                case 58380:
                    return 16778831;
                case 58381:
                    return 16778827;
                case 58382:
                    return 16778794;
                case 58383:
                    return 16778824;
                case 58384:
                    return 16778826;
                case 58385:
                    return 16778821;
                case 58386:
                    return 16778778;
                case 58387:
                    return 16778810;
                case 58388:
                    return 16779640;
                case 58389:
                    return 16778780;
                case 58390:
                    return 16778809;
                case 58391:
                    return 16778802;
                case 58392:
                    return 16778800;
                case 58393:
                    return 16777907;
                case 58394:
                    return 16777921;
                case 58395:
                    return 16777915;
                case 58396:
                    return 16777922;
                case 58397:
                    return 16778931;
                case 58398:
                    return 16777959;
                case 58399:
                    return 16777983;
                case 58400:
                    return 16777965;
                case 58401:
                    return 16777977;
                case 58402:
                    return 16777989;
                case 58403:
                    return 16778855;
                case 58404:
                    return 16778867;
                case 58405:
                    return 16778489;
                case 58406:
                    return 16778880;
                case 58407:
                    return 16778901;
                case 58408:
                    return 16778307;
                case 58409:
                    return 16778332;
                case 58410:
                    return 16777710;
                case 58411:
                    return 16777747;
                case 58412:
                    return 16777695;
                case 58413:
                    return 16777761;
                case 58414:
                    return 16778957;
                case 58415:
                    return 16778958;
                case 58416:
                    return 16778950;
                case 58417:
                    return 16778949;
                case 58418:
                    return 16778951;
                case 58419:
                    return 16777680;
                case 58420:
                    return 16778939;
                case 58421:
                    return 16778936;
                case 58422:
                    return 16777664;
                case 58423:
                    return 16778501;
                case 58424:
                    return 16777665;
                case 58425:
                    return 16777670;
                case 58426:
                    return 16777669;
                case 58427:
                    return 16777666;
                case 58428:
                    return 16777522;
                case 58429:
                    return 16778490;
                case 58430:
                    return 16777530;
                case 58431:
                    return 16777621;
                case 58432:
                    return 16777658;
                case 58433:
                    return 16777869;
                case 58434:
                    return 16777667;
                case 58435:
                    return 16777520;
                case 58436:
                    return 16777580;
                case 58437:
                    return 16777649;
                case 58438:
                    return 16777668;
                case 58439:
                    return 16777585;
                case 58440:
                    return 16777656;
                case 58441:
                    return 16777525;
                case 58442:
                    return 16777527;
                case 58443:
                    return 16777523;
                case 58444:
                    return 16777528;
                case 58625:
                    return 16777816;
                case 58626:
                    return 16777686;
                case 58627:
                    return 16777687;
                case 58628:
                    return 16777819;
                case 58629:
                    return 16777822;
                case 58630:
                    return 16777823;
                case 58631:
                    return 16777684;
                case 58632:
                    return 16777820;
                case 58633:
                    return 16778772;
                case 58635:
                    return 16777366;
                case 58636:
                    return 16777487;
                case 58637:
                    return 16777326;
                case 58638:
                    return 16777305;
                case 58639:
                    return 16777362;
                case 58640:
                    return 16777328;
                case 58641:
                    return 16777318;
                case 58642:
                    return 16777443;
                case 58643:
                    return 16777295;
                case 58644:
                    return 16777374;
                case 58645:
                    return 16778351;
                case 58646:
                    return 16778357;
                case 58647:
                    return 16778369;
                case 58648:
                    return 16778375;
                case 58649:
                    return 16778381;
                case 58650:
                    return 16778387;
                case 58651:
                    return 16778399;
                case 58652:
                    return 16778405;
                case 58653:
                    return 16778773;
                case 58654:
                    return 16778442;
                case 58655:
                    return 16778448;
                case 58656:
                    return 16777887;
                case 58657:
                    return 16777881;
                case 58658:
                    return 16777875;
                case 58659:
                    return 16777879;
                case 58660:
                    return 16777900;
                case 58661:
                    return 16777870;
                case 58662:
                    return 16777867;
                case 58663:
                    return 16777883;
                case 58664:
                    return 16777861;
                case 58665:
                    return 16777860;
                case 58666:
                    return 16777901;
                case 58667:
                    return 16777889;
                case 58668:
                    return 16777891;
                case 58669:
                    return 16777856;
                case 58670:
                    return 16777863;
                case 58671:
                    return 16777866;
                case 58672:
                    return 16777886;
                case 58673:
                    return 16777899;
                case 58674:
                    return 16777232;
                case 58675:
                    return 16777233;
                case 58676:
                    return 16777236;
                case 58677:
                    return 16777234;
                case 58678:
                    return 16778008;
                case 58679:
                    return 16779578;
                case 126980:
                    return 16777230;
                case 127183:
                    return 16777231;
                case 127344:
                    return 16777232;
                case 127345:
                    return 16777233;
                case 127358:
                    return 16777234;
                case 127359:
                    return 16777235;
                case 127374:
                    return 16777236;
                case 127377:
                    return 16777237;
                case 127378:
                    return 16777238;
                case 127379:
                    return 16777239;
                case 127380:
                    return 16777240;
                case 127381:
                    return 16777241;
                case 127382:
                    return 16777242;
                case 127383:
                    return 16777243;
                case 127384:
                    return 16777244;
                case 127385:
                    return 16777245;
                case 127386:
                    return 16777246;
                case 127462:
                    switch (c0914b.next())
                    {
                        case 127464:
                            return 33554463;
                        case 127465:
                            return 33554464;
                        case 127466:
                            return 33554465;
                        case 127467:
                            return 33554466;
                        case 127468:
                            return 33554467;
                        case 127470:
                            return 33554468;
                        case 127473:
                            return 33554469;
                        case 127474:
                            return 33554470;
                        case 127476:
                            return 33554471;
                        case 127478:
                            return 33554472;
                        case 127479:
                            return 33554473;
                        case 127480:
                            return 33554474;
                        case 127481:
                            return 33554475;
                        case 127482:
                            return 33554476;
                        case 127484:
                            return 33554477;
                        case 127485:
                            return 33554478;
                        case 127487:
                            return 33554479;
                        default:
                            return -1;
                    }
                case 127463:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554480;
                        case 127463:
                            return 33554481;
                        case 127465:
                            return 33554482;
                        case 127466:
                            return 33554483;
                        case 127467:
                            return 33554484;
                        case 127468:
                            return 33554485;
                        case 127469:
                            return 33554486;
                        case 127470:
                            return 33554487;
                        case 127471:
                            return 33554488;
                        case 127473:
                            return 33554489;
                        case 127474:
                            return 33554490;
                        case 127475:
                            return 33554491;
                        case 127476:
                            return 33554492;
                        case 127478:
                            return 33554493;
                        case 127479:
                            return 33554494;
                        case 127480:
                            return 33554495;
                        case 127481:
                            return 33554496;
                        case 127483:
                            return 33554497;
                        case 127484:
                            return 33554498;
                        case 127486:
                            return 33554499;
                        case 127487:
                            return 33554500;
                        default:
                            return -1;
                    }
                case 127464:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554501;
                        case 127464:
                            return 33554502;
                        case 127465:
                            return 33554503;
                        case 127467:
                            return 33554504;
                        case 127468:
                            return 33554505;
                        case 127469:
                            return 33554506;
                        case 127470:
                            return 33554507;
                        case 127472:
                            return 33554508;
                        case 127473:
                            return 33554509;
                        case 127474:
                            return 33554510;
                        case 127475:
                            return 33554511;
                        case 127476:
                            return 33554512;
                        case 127477:
                            return 33554513;
                        case 127479:
                            return 33554514;
                        case 127482:
                            return 33554515;
                        case 127483:
                            return 33554516;
                        case 127484:
                            return 33554517;
                        case 127485:
                            return 33554518;
                        case 127486:
                            return 33554519;
                        case 127487:
                            return 33554520;
                        default:
                            return -1;
                    }
                case 127465:
                    switch (c0914b.next())
                    {
                        case 127466:
                            return 33554521;
                        case 127468:
                            return 33554522;
                        case 127471:
                            return 33554523;
                        case 127472:
                            return 33554524;
                        case 127474:
                            return 33554525;
                        case 127476:
                            return 33554526;
                        case 127487:
                            return 33554527;
                        default:
                            return -1;
                    }
                case 127466:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554528;
                        case 127464:
                            return 33554529;
                        case 127466:
                            return 33554530;
                        case 127468:
                            return 33554531;
                        case 127469:
                            return 33554532;
                        case 127479:
                            return 33554533;
                        case 127480:
                            return 33554534;
                        case 127481:
                            return 33554535;
                        case 127482:
                            return 33554536;
                        default:
                            return -1;
                    }
                case 127467:
                    switch (c0914b.next())
                    {
                        case 127470:
                            return 33554537;
                        case 127471:
                            return 33554538;
                        case 127472:
                            return 33554539;
                        case 127474:
                            return 33554540;
                        case 127476:
                            return 33554541;
                        case 127479:
                            return 33554542;
                        default:
                            return -1;
                    }
                case 127468:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554543;
                        case 127463:
                            return 33554544;
                        case 127465:
                            return 33554545;
                        case 127466:
                            return 33554546;
                        case 127467:
                            return 33554547;
                        case 127468:
                            return 33554548;
                        case 127469:
                            return 33554549;
                        case 127470:
                            return 33554550;
                        case 127473:
                            return 33554551;
                        case 127474:
                            return 33554552;
                        case 127475:
                            return 33554553;
                        case 127477:
                            return 33554554;
                        case 127478:
                            return 33554555;
                        case 127479:
                            return 33554556;
                        case 127480:
                            return 33554557;
                        case 127481:
                            return 33554558;
                        case 127482:
                            return 33554559;
                        case 127484:
                            return 33554560;
                        case 127486:
                            return 33554561;
                        default:
                            return -1;
                    }
                case 127469:
                    switch (c0914b.next())
                    {
                        case 127472:
                            return 33554562;
                        case 127474:
                            return 33554563;
                        case 127475:
                            return 33554564;
                        case 127479:
                            return 33554565;
                        case 127481:
                            return 33554566;
                        case 127482:
                            return 33554567;
                        default:
                            return -1;
                    }
                case 127470:
                    switch (c0914b.next())
                    {
                        case 127464:
                            return 33554568;
                        case 127465:
                            return 33554569;
                        case 127466:
                            return 33554570;
                        case 127473:
                            return 33554571;
                        case 127474:
                            return 33554572;
                        case 127475:
                            return 33554573;
                        case 127476:
                            return 33554574;
                        case 127478:
                            return 33554575;
                        case 127479:
                            return 33554576;
                        case 127480:
                            return 33554577;
                        case 127481:
                            return 33554578;
                        default:
                            return -1;
                    }
                case 127471:
                    switch (c0914b.next())
                    {
                        case 127466:
                            return 33554579;
                        case 127474:
                            return 33554580;
                        case 127476:
                            return 33554581;
                        case 127477:
                            return 33554582;
                        default:
                            return -1;
                    }
                case 127472:
                    switch (c0914b.next())
                    {
                        case 127466:
                            return 33554583;
                        case 127468:
                            return 33554584;
                        case 127469:
                            return 33554585;
                        case 127470:
                            return 33554586;
                        case 127474:
                            return 33554587;
                        case 127475:
                            return 33554588;
                        case 127477:
                            return 33554589;
                        case 127479:
                            return 33554590;
                        case 127484:
                            return 33554591;
                        case 127486:
                            return 33554592;
                        case 127487:
                            return 33554593;
                        default:
                            return -1;
                    }
                case 127473:
                    next3 = c0914b.next();
                    if (next3 == 127470)
                    {
                        return 33554597;
                    }
                    if (next3 == 127472)
                    {
                        return 33554598;
                    }
                    if (next3 == 127486)
                    {
                        return 33554604;
                    }
                    switch (next3)
                    {
                        case 127462:
                            return 33554594;
                        case 127463:
                            return 33554595;
                        case 127464:
                            return 33554596;
                        default:
                            switch (next3)
                            {
                                case 127479:
                                    return 33554599;
                                case 127480:
                                    return 33554600;
                                case 127481:
                                    return 33554601;
                                case 127482:
                                    return 33554602;
                                case 127483:
                                    return 33554603;
                                default:
                                    return -1;
                            }
                    }
                case 127474:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554605;
                        case 127464:
                            return 33554606;
                        case 127465:
                            return 33554607;
                        case 127466:
                            return 33554608;
                        case 127467:
                            return 33554609;
                        case 127468:
                            return 33554610;
                        case 127469:
                            return 33554611;
                        case 127472:
                            return 33554612;
                        case 127473:
                            return 33554613;
                        case 127474:
                            return 33554614;
                        case 127475:
                            return 33554615;
                        case 127476:
                            return 33554616;
                        case 127477:
                            return 33554617;
                        case 127478:
                            return 33554618;
                        case 127479:
                            return 33554619;
                        case 127480:
                            return 33554620;
                        case 127481:
                            return 33554621;
                        case 127482:
                            return 33554622;
                        case 127483:
                            return 33554623;
                        case 127484:
                            return 33554624;
                        case 127485:
                            return 33554625;
                        case 127486:
                            return 33554626;
                        case 127487:
                            return 33554627;
                        default:
                            return -1;
                    }
                case 127475:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554628;
                        case 127464:
                            return 33554629;
                        case 127466:
                            return 33554630;
                        case 127467:
                            return 33554631;
                        case 127468:
                            return 33554632;
                        case 127470:
                            return 33554633;
                        case 127473:
                            return 33554634;
                        case 127476:
                            return 33554635;
                        case 127477:
                            return 33554636;
                        case 127479:
                            return 33554637;
                        case 127482:
                            return 33554638;
                        case 127487:
                            return 33554639;
                        default:
                            return -1;
                    }
                case 127476:
                    if (c0914b.next() == 127474)
                    {
                        i2 = 33554640;
                    }
                    return i2;
                case 127477:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554641;
                        case 127466:
                            return 33554642;
                        case 127467:
                            return 33554643;
                        case 127468:
                            return 33554644;
                        case 127469:
                            return 33554645;
                        case 127472:
                            return 33554646;
                        case 127473:
                            return 33554647;
                        case 127474:
                            return 33554648;
                        case 127475:
                            return 33554649;
                        case 127479:
                            return 33554650;
                        case 127480:
                            return 33554651;
                        case 127481:
                            return 33554652;
                        case 127484:
                            return 33554653;
                        case 127486:
                            return 33554654;
                        default:
                            return -1;
                    }
                case 127478:
                    if (c0914b.next() == 127462)
                    {
                        i2 = 33554655;
                    }
                    return i2;
                case 127479:
                    switch (c0914b.next())
                    {
                        case 127466:
                            return 33554656;
                        case 127476:
                            return 33554657;
                        case 127480:
                            return 33554658;
                        case 127482:
                            return 33554659;
                        case 127484:
                            return 33554660;
                        default:
                            return -1;
                    }
                case 127480:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554661;
                        case 127463:
                            return 33554662;
                        case 127464:
                            return 33554663;
                        case 127465:
                            return 33554664;
                        case 127466:
                            return 33554665;
                        case 127468:
                            return 33554666;
                        case 127469:
                            return 33554667;
                        case 127470:
                            return 33554668;
                        case 127471:
                            return 33554669;
                        case 127472:
                            return 33554670;
                        case 127473:
                            return 33554671;
                        case 127474:
                            return 33554672;
                        case 127475:
                            return 33554673;
                        case 127476:
                            return 33554674;
                        case 127479:
                            return 33554675;
                        case 127480:
                            return 33554676;
                        case 127481:
                            return 33554677;
                        case 127483:
                            return 33554678;
                        case 127485:
                            return 33554679;
                        case 127486:
                            return 33554680;
                        case 127487:
                            return 33554681;
                        default:
                            return -1;
                    }
                case 127481:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554682;
                        case 127464:
                            return 33554683;
                        case 127465:
                            return 33554684;
                        case 127467:
                            return 33554685;
                        case 127468:
                            return 33554686;
                        case 127469:
                            return 33554687;
                        case 127471:
                            return 33554688;
                        case 127472:
                            return 33554689;
                        case 127473:
                            return 33554690;
                        case 127474:
                            return 33554691;
                        case 127475:
                            return 33554692;
                        case 127476:
                            return 33554693;
                        case 127479:
                            return 33554694;
                        case 127481:
                            return 33554695;
                        case 127483:
                            return 33554696;
                        case 127484:
                            return 33554697;
                        case 127487:
                            return 33554698;
                        default:
                            return -1;
                    }
                case 127482:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554699;
                        case 127468:
                            return 33554700;
                        case 127474:
                            return 33554701;
                        case 127475:
                            return 33554702;
                        case 127480:
                            return 33554703;
                        case 127486:
                            return 33554704;
                        case 127487:
                            return 33554705;
                        default:
                            return -1;
                    }
                case 127483:
                    switch (c0914b.next())
                    {
                        case 127462:
                            return 33554706;
                        case 127464:
                            return 33554707;
                        case 127466:
                            return 33554708;
                        case 127468:
                            return 33554709;
                        case 127470:
                            return 33554710;
                        case 127475:
                            return 33554711;
                        case 127482:
                            return 33554712;
                        default:
                            return -1;
                    }
                case 127484:
                    next3 = c0914b.next();
                    if (next3 == 127467)
                    {
                        return 33554713;
                    }
                    if (next3 != 127480)
                    {
                        return -1;
                    }
                    return 33554714;
                case 127485:
                    switch (c0914b.next())
                    {
                        case 127466:
                            return 33555044;
                        case 127472:
                            return 33554715;
                        case 127480:
                            return 33555045;
                        case 127481:
                            return 33555047;
                        case 127484:
                            return 33555046;
                        default:
                            return -1;
                    }
                case 127486:
                    next3 = c0914b.next();
                    if (next3 == 127466)
                    {
                        return 33554716;
                    }
                    if (next3 != 127481)
                    {
                        return -1;
                    }
                    return 33554717;
                case 127487:
                    next3 = c0914b.next();
                    if (next3 == 127462)
                    {
                        return 33554718;
                    }
                    if (next3 == 127474)
                    {
                        return 33554719;
                    }
                    if (next3 != 127484)
                    {
                        return -1;
                    }
                    return 33554720;
                case 127489:
                    return 16777505;
                case 127490:
                    return 16777506;
                case 127514:
                    return 16777507;
                case 127535:
                    return 16777508;
                case 127538:
                    return 16777509;
                case 127539:
                    return 16777510;
                case 127540:
                    return 16777511;
                case 127541:
                    return 16777512;
                case 127542:
                    return 16777513;
                case 127543:
                    return 16777514;
                case 127544:
                    return 16777515;
                case 127545:
                    return 16777516;
                case 127546:
                    return 16777517;
                case 127568:
                    return 16777518;
                case 127569:
                    return 16777519;
                case 127744:
                    return 16777520;
                case 127745:
                    return 16777521;
                case 127746:
                    return 16777522;
                case 127747:
                    return 16777523;
                case 127748:
                    return 16777524;
                case 127749:
                    return 16777525;
                case 127750:
                    return 16777526;
                case 127751:
                    return 16777527;
                case 127752:
                    return 16777528;
                case 127753:
                    return 16777529;
                case 127754:
                    return 16777530;
                case 127755:
                    return 16777531;
                case 127756:
                    return 16777532;
                case 127757:
                    return 16777533;
                case 127758:
                    return 16777534;
                case 127759:
                    return 16777535;
                case 127760:
                    return 16777536;
                case 127761:
                    return 16777537;
                case 127762:
                    return 16777538;
                case 127763:
                    return 16777539;
                case 127764:
                    return 16777540;
                case 127765:
                    return 16777541;
                case 127766:
                    return 16777542;
                case 127767:
                    return 16777543;
                case 127768:
                    return 16777544;
                case 127769:
                    return 16777545;
                case 127770:
                    return 16777546;
                case 127771:
                    return 16777547;
                case 127772:
                    return 16777548;
                case 127773:
                    return 16777549;
                case 127774:
                    return 16777550;
                case 127775:
                    return 16777551;
                case 127776:
                    return 16777552;
                case 127777:
                    return 16777553;
                case 127780:
                    return 16777554;
                case 127781:
                    return 16777555;
                case 127782:
                    return 16777556;
                case 127783:
                    return 16777557;
                case 127784:
                    return 16777558;
                case 127785:
                    return 16777559;
                case 127786:
                    return 16777560;
                case 127787:
                    return 16777561;
                case 127788:
                    return 16777562;
                case 127789:
                    return 16777563;
                case 127790:
                    return 16777564;
                case 127791:
                    return 16777565;
                case 127792:
                    return 16777566;
                case 127793:
                    return 16777567;
                case 127794:
                    return 16777568;
                case 127795:
                    return 16777569;
                case 127796:
                    return 16777570;
                case 127797:
                    return 16777571;
                case 127798:
                    return 16777572;
                case 127799:
                    return 16777573;
                case 127800:
                    return 16777574;
                case 127801:
                    return 16777575;
                case 127802:
                    return 16777576;
                case 127803:
                    return 16777577;
                case 127804:
                    return 16777578;
                case 127805:
                    return 16777579;
                case 127806:
                    return 16777580;
                case 127807:
                    return 16777581;
                case 127808:
                    return 16777582;
                case 127809:
                    return 16777583;
                case 127810:
                    return 16777584;
                case 127811:
                    return 16777585;
                case 127812:
                    return 16777586;
                case 127813:
                    return 16777587;
                case 127814:
                    return 16777588;
                case 127815:
                    return 16777589;
                case 127816:
                    return 16777590;
                case 127817:
                    return 16777591;
                case 127818:
                    return 16777592;
                case 127819:
                    return 16777593;
                case 127820:
                    return 16777594;
                case 127821:
                    return 16777595;
                case 127822:
                    return 16777596;
                case 127823:
                    return 16777597;
                case 127824:
                    return 16777598;
                case 127825:
                    return 16777599;
                case 127826:
                    return 16777600;
                case 127827:
                    return 16777601;
                case 127828:
                    return 16777602;
                case 127829:
                    return 16777603;
                case 127830:
                    return 16777604;
                case 127831:
                    return 16777605;
                case 127832:
                    return 16777606;
                case 127833:
                    return 16777607;
                case 127834:
                    return 16777608;
                case 127835:
                    return 16777609;
                case 127836:
                    return 16777610;
                case 127837:
                    return 16777611;
                case 127838:
                    return 16777612;
                case 127839:
                    return 16777613;
                case 127840:
                    return 16777614;
                case 127841:
                    return 16777615;
                case 127842:
                    return 16777616;
                case 127843:
                    return 16777617;
                case 127844:
                    return 16777618;
                case 127845:
                    return 16777619;
                case 127846:
                    return 16777620;
                case 127847:
                    return 16777621;
                case 127848:
                    return 16777622;
                case 127849:
                    return 16777623;
                case 127850:
                    return 16777624;
                case 127851:
                    return 16777625;
                case 127852:
                    return 16777626;
                case 127853:
                    return 16777627;
                case 127854:
                    return 16777628;
                case 127855:
                    return 16777629;
                case 127856:
                    return 16777630;
                case 127857:
                    return 16777631;
                case 127858:
                    return 16777632;
                case 127859:
                    return 16777633;
                case 127860:
                    return 16777634;
                case 127861:
                    return 16777635;
                case 127862:
                    return 16777636;
                case 127863:
                    return 16777637;
                case 127864:
                    return 16777638;
                case 127865:
                    return 16777639;
                case 127866:
                    return 16777640;
                case 127867:
                    return 16777641;
                case 127868:
                    return 16777642;
                case 127869:
                    return 16777643;
                case 127870:
                    return 16777644;
                case 127871:
                    return 16777645;
                case 127872:
                    return 16777646;
                case 127873:
                    return 16777647;
                case 127874:
                    return 16777648;
                case 127875:
                    return 16777649;
                case 127876:
                    return 16777650;
                case 127877:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33554867;
                        case 127996:
                            return 33554868;
                        case 127997:
                            return 33554869;
                        case 127998:
                            return 33554870;
                        case 127999:
                            return 33554871;
                        default:
                            return 16777656;
                    }
                case 127878:
                    return 16777657;
                case 127879:
                    return 16777658;
                case 127880:
                    return 16777659;
                case 127881:
                    return 16777660;
                case 127882:
                    return 16777661;
                case 127883:
                    return 16777662;
                case 127884:
                    return 16777663;
                case 127885:
                    return 16777664;
                case 127886:
                    return 16777665;
                case 127887:
                    return 16777666;
                case 127888:
                    return 16777667;
                case 127889:
                    return 16777668;
                case 127890:
                    return 16777669;
                case 127891:
                    return 16777670;
                case 127894:
                    return 16777671;
                case 127895:
                    return 16777672;
                case 127897:
                    return 16777673;
                case 127898:
                    return 16777674;
                case 127899:
                    return 16777675;
                case 127902:
                    return 16777676;
                case 127903:
                    return 16777677;
                case 127904:
                    return 16777678;
                case 127905:
                    return 16777679;
                case 127906:
                    return 16777680;
                case 127907:
                    return 16777681;
                case 127908:
                    return 16777682;
                case 127909:
                    return 16777683;
                case 127910:
                    return 16777684;
                case 127911:
                    return 16777685;
                case 127912:
                    return 16777686;
                case 127913:
                    return 16777687;
                case 127914:
                    return 16777688;
                case 127915:
                    return 16777689;
                case 127916:
                    return 16777690;
                case 127917:
                    return 16777691;
                case 127918:
                    return 16777692;
                case 127919:
                    return 16777693;
                case 127920:
                    return 16777694;
                case 127921:
                    return 16777695;
                case 127922:
                    return 16777696;
                case 127923:
                    return 16777697;
                case 127924:
                    return 16777698;
                case 127925:
                    return 16777699;
                case 127926:
                    return 16777700;
                case 127927:
                    return 16777701;
                case 127928:
                    return 16777702;
                case 127929:
                    return 16777703;
                case 127930:
                    return 16777704;
                case 127931:
                    return 16777705;
                case 127932:
                    return 16777706;
                case 127933:
                    return 16777707;
                case 127934:
                    return 16777708;
                case 127935:
                    return 16777709;
                case 127936:
                    return 16777710;
                case 127937:
                    return 16777711;
                case 127938:
                    return 16777712;
                case 127939:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554930;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554930 : 67109362;
                                }
                                else
                                {
                                    return 67109361;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554932;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554932 : 67109364;
                                }
                                else
                                {
                                    return 67109363;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554934;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554934 : 67109366;
                                }
                                else
                                {
                                    return 67109365;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554936;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554936 : 67109368;
                                }
                                else
                                {
                                    return 67109367;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554938;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554938 : 67109370;
                                }
                                else
                                {
                                    return 67109369;
                                }
                            default:
                                return 16777725;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 == 9792)
                    {
                        return 50332155;
                    }
                    if (next2 != 9794)
                    {
                        return 16777725;
                    }
                    return 50332156;
                case 127940:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554943;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554943 : 67109375;
                                }
                                else
                                {
                                    return 67109374;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554945;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554945 : 67109377;
                                }
                                else
                                {
                                    return 67109376;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554947;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554947 : 67109379;
                                }
                                else
                                {
                                    return 67109378;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554949;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554949 : 67109381;
                                }
                                else
                                {
                                    return 67109380;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554951;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554951 : 67109383;
                                }
                                else
                                {
                                    return 67109382;
                                }
                            default:
                                return 16777738;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 == 9792)
                    {
                        return 50332168;
                    }
                    if (next2 != 9794)
                    {
                        return 16777738;
                    }
                    return 50332169;
                case 127941:
                    return 16777739;
                case 127942:
                    return 16777740;
                case 127943:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33554957;
                        case 127996:
                            return 33554958;
                        case 127997:
                            return 33554959;
                        case 127998:
                            return 33554960;
                        case 127999:
                            return 33554961;
                        default:
                            return 16777746;
                    }
                case 127944:
                    return 16777747;
                case 127945:
                    return 16777748;
                case 127946:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554966;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554966 : 67109398;
                                }
                                else
                                {
                                    return 67109397;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554968;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554968 : 67109400;
                                }
                                else
                                {
                                    return 67109399;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554970;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554970 : 67109402;
                                }
                                else
                                {
                                    return 67109401;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554972;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554972 : 67109404;
                                }
                                else
                                {
                                    return 67109403;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554974;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554974 : 67109406;
                                }
                                else
                                {
                                    return 67109405;
                                }
                            default:
                                return 16777761;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16777761 : 50332192;
                    }
                    else
                    {
                        return 50332191;
                    }
                case 127947:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554979;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554979 : 67109411;
                                }
                                else
                                {
                                    return 67109410;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554981;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554981 : 67109413;
                                }
                                else
                                {
                                    return 67109412;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554983;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554983 : 67109415;
                                }
                                else
                                {
                                    return 67109414;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554985;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554985 : 67109417;
                                }
                                else
                                {
                                    return 67109416;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554987;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554987 : 67109419;
                                }
                                else
                                {
                                    return 67109418;
                                }
                            default:
                                return 16777774;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16777774 : 50332205;
                    }
                    else
                    {
                        return 50332204;
                    }
                case 127948:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554992;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554992 : 67109424;
                                }
                                else
                                {
                                    return 67109423;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554994;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554994 : 67109426;
                                }
                                else
                                {
                                    return 67109425;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554996;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554996 : 67109428;
                                }
                                else
                                {
                                    return 67109427;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33554998;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33554998 : 67109430;
                                }
                                else
                                {
                                    return 67109429;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555000;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555000 : 67109432;
                                }
                                else
                                {
                                    return 67109431;
                                }
                            default:
                                return 16777787;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16777787 : 50332218;
                    }
                    else
                    {
                        return 50332217;
                    }
                case 127949:
                    return 16777788;
                case 127950:
                    return 16777789;
                case 127951:
                    return 16777790;
                case 127952:
                    return 16777791;
                case 127953:
                    return 16777792;
                case 127954:
                    return 16777793;
                case 127955:
                    return 16777794;
                case 127956:
                    return 16777795;
                case 127957:
                    return 16777796;
                case 127958:
                    return 16777797;
                case 127959:
                    return 16777798;
                case 127960:
                    return 16777799;
                case 127961:
                    return 16777800;
                case 127962:
                    return 16777801;
                case 127963:
                    return 16777802;
                case 127964:
                    return 16777803;
                case 127965:
                    return 16777804;
                case 127966:
                    return 16777805;
                case 127967:
                    return 16777806;
                case 127968:
                    return 16777807;
                case 127969:
                    return 16777808;
                case 127970:
                    return 16777809;
                case 127971:
                    return 16777810;
                case 127972:
                    return 16777811;
                case 127973:
                    return 16777812;
                case 127974:
                    return 16777813;
                case 127975:
                    return 16777814;
                case 127976:
                    return 16777815;
                case 127977:
                    return 16777816;
                case 127978:
                    return 16777817;
                case 127979:
                    return 16777818;
                case 127980:
                    return 16777819;
                case 127981:
                    return 16777820;
                case 127982:
                    return 16777821;
                case 127983:
                    return 16777822;
                case 127984:
                    return 16777823;
                case 127987:
                    if (c0914b.next() != 8205)
                    {
                        return 16777826;
                    }
                    next3 = c0914b.next();
                    if (next3 != 9895)
                    {
                        return next3 != 127752 ? 16777826 : 50332256;
                    }
                    else
                    {
                        return 50332257;
                    }
                case 127988:
                    next3 = c0914b.next();
                    int i3 = 16777832;
                    if (next3 == 8205)
                    {
                        if (c0914b.next() == 9760)
                        {
                            i3 = 50332259;
                        }
                        return i3;
                    }
                    else if (next3 != 917607)
                    {
                        if (next3 != 917621 || c0914b.next() != 917619 || c0914b.next() != 917620 || c0914b.next() != 917624)
                        {
                            return 16777832;
                        }
                        if (c0914b.next() == 917631)
                        {
                            i3 = 100663911;
                        }
                        return i3;
                    }
                    else if (c0914b.next() != 917602)
                    {
                        return 16777832;
                    }
                    else
                    {
                        next3 = c0914b.next();
                        if (next3 != 917605)
                        {
                            if (next3 != 917619)
                            {
                                if (next3 != 917623 || c0914b.next() != 917612 || c0914b.next() != 917619)
                                {
                                    return 16777832;
                                }
                                if (c0914b.next() == 917631)
                                {
                                    i3 = 117441126;
                                }
                                return i3;
                            }
                            else if (c0914b.next() != 917603 || c0914b.next() != 917620)
                            {
                                return 16777832;
                            }
                            else
                            {
                                if (c0914b.next() == 917631)
                                {
                                    i3 = 117441125;
                                }
                                return i3;
                            }
                        }
                        else if (c0914b.next() != 917614 || c0914b.next() != 917607)
                        {
                            return 16777832;
                        }
                        else
                        {
                            if (c0914b.next() == 917631)
                            {
                                i3 = 117441124;
                            }
                            return i3;
                        }
                    }
                case 127989:
                    return 16777833;
                case 127991:
                    return 16777834;
                case 127992:
                    return 16777835;
                case 127993:
                    return 16777836;
                case 127994:
                    return 16777837;
                case 127995:
                    return 16777838;
                case 127996:
                    return 16777839;
                case 127997:
                    return 16777840;
                case 127998:
                    return 16777841;
                case 127999:
                    return 16777842;
                case 128000:
                    return 16777843;
                case 128001:
                    return 16777844;
                case 128002:
                    return 16777845;
                case 128003:
                    return 16777846;
                case 128004:
                    return 16777847;
                case 128005:
                    return 16777848;
                case 128006:
                    return 16777849;
                case 128007:
                    return 16777850;
                case 128008:
                    return 16777851;
                case 128009:
                    return 16777852;
                case 128010:
                    return 16777853;
                case 128011:
                    return 16777854;
                case 128012:
                    return 16777855;
                case 128013:
                    return 16777856;
                case 128014:
                    return 16777857;
                case 128015:
                    return 16777858;
                case 128016:
                    return 16777859;
                case 128017:
                    return 16777860;
                case 128018:
                    return 16777861;
                case 128019:
                    return 16777862;
                case 128020:
                    return 16777863;
                case 128021:
                    return 16777864;
                case 128022:
                    return 16777865;
                case 128023:
                    return 16777866;
                case 128024:
                    return 16777867;
                case 128025:
                    return 16777868;
                case 128026:
                    return 16777869;
                case 128027:
                    return 16777870;
                case 128028:
                    return 16777871;
                case 128029:
                    return 16777872;
                case 128030:
                    return 16777873;
                case 128031:
                    return 16777874;
                case 128032:
                    return 16777875;
                case 128033:
                    return 16777876;
                case 128034:
                    return 16777877;
                case 128035:
                    return 16777878;
                case 128036:
                    return 16777879;
                case 128037:
                    return 16777880;
                case 128038:
                    return 16777881;
                case 128039:
                    return 16777882;
                case 128040:
                    return 16777883;
                case 128041:
                    return 16777884;
                case 128042:
                    return 16777885;
                case 128043:
                    return 16777886;
                case 128044:
                    return 16777887;
                case 128045:
                    return 16777888;
                case 128046:
                    return 16777889;
                case 128047:
                    return 16777890;
                case 128048:
                    return 16777891;
                case 128049:
                    return 16777892;
                case 128050:
                    return 16777893;
                case 128051:
                    return 16777894;
                case 128052:
                    return 16777895;
                case 128053:
                    return 16777896;
                case 128054:
                    return 16777897;
                case 128055:
                    return 16777898;
                case 128056:
                    return 16777899;
                case 128057:
                    return 16777900;
                case 128058:
                    return 16777901;
                case 128059:
                    return 16777902;
                case 128060:
                    return 16777903;
                case 128061:
                    return 16777904;
                case 128062:
                    return 16777905;
                case 128063:
                    return 16777906;
                case 128064:
                    return 16777907;
                case 128065:
                    if (c0914b.next() != 8205)
                    {
                        return 16777909;
                    }
                    return c0914b.next() == 128488 ? 50332340 : 16777909;
                case 128066:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555126;
                        case 127996:
                            return 33555127;
                        case 127997:
                            return 33555128;
                        case 127998:
                            return 33555129;
                        case 127999:
                            return 33555130;
                        default:
                            return 16777915;
                    }
                case 128067:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555132;
                        case 127996:
                            return 33555133;
                        case 127997:
                            return 33555134;
                        case 127998:
                            return 33555135;
                        case 127999:
                            return 33555136;
                        default:
                            return 16777921;
                    }
                case 128068:
                    return 16777922;
                case 128069:
                    return 16777923;
                case 128070:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555140;
                        case 127996:
                            return 33555141;
                        case 127997:
                            return 33555142;
                        case 127998:
                            return 33555143;
                        case 127999:
                            return 33555144;
                        default:
                            return 16777929;
                    }
                case 128071:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555146;
                        case 127996:
                            return 33555147;
                        case 127997:
                            return 33555148;
                        case 127998:
                            return 33555149;
                        case 127999:
                            return 33555150;
                        default:
                            return 16777935;
                    }
                case 128072:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555152;
                        case 127996:
                            return 33555153;
                        case 127997:
                            return 33555154;
                        case 127998:
                            return 33555155;
                        case 127999:
                            return 33555156;
                        default:
                            return 16777941;
                    }
                case 128073:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555158;
                        case 127996:
                            return 33555159;
                        case 127997:
                            return 33555160;
                        case 127998:
                            return 33555161;
                        case 127999:
                            return 33555162;
                        default:
                            return 16777947;
                    }
                case 128074:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555164;
                        case 127996:
                            return 33555165;
                        case 127997:
                            return 33555166;
                        case 127998:
                            return 33555167;
                        case 127999:
                            return 33555168;
                        default:
                            return 16777953;
                    }
                case 128075:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555170;
                        case 127996:
                            return 33555171;
                        case 127997:
                            return 33555172;
                        case 127998:
                            return 33555173;
                        case 127999:
                            return 33555174;
                        default:
                            return 16777959;
                    }
                case 128076:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555176;
                        case 127996:
                            return 33555177;
                        case 127997:
                            return 33555178;
                        case 127998:
                            return 33555179;
                        case 127999:
                            return 33555180;
                        default:
                            return 16777965;
                    }
                case 128077:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555182;
                        case 127996:
                            return 33555183;
                        case 127997:
                            return 33555184;
                        case 127998:
                            return 33555185;
                        case 127999:
                            return 33555186;
                        default:
                            return 16777971;
                    }
                case 128078:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555188;
                        case 127996:
                            return 33555189;
                        case 127997:
                            return 33555190;
                        case 127998:
                            return 33555191;
                        case 127999:
                            return 33555192;
                        default:
                            return 16777977;
                    }
                case 128079:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555194;
                        case 127996:
                            return 33555195;
                        case 127997:
                            return 33555196;
                        case 127998:
                            return 33555197;
                        case 127999:
                            return 33555198;
                        default:
                            return 16777983;
                    }
                case 128080:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555200;
                        case 127996:
                            return 33555201;
                        case 127997:
                            return 33555202;
                        case 127998:
                            return 33555203;
                        case 127999:
                            return 33555204;
                        default:
                            return 16777989;
                    }
                case 128081:
                    return 16777990;
                case 128082:
                    return 16777991;
                case 128083:
                    return 16777992;
                case 128084:
                    return 16777993;
                case 128085:
                    return 16777994;
                case 128086:
                    return 16777995;
                case 128087:
                    return 16777996;
                case 128088:
                    return 16777997;
                case 128089:
                    return 16777998;
                case 128090:
                    return 16777999;
                case 128091:
                    return 16778000;
                case 128092:
                    return 16778001;
                case 128093:
                    return 16778002;
                case 128094:
                    return 16778003;
                case 128095:
                    return 16778004;
                case 128096:
                    return 16778005;
                case 128097:
                    return 16778006;
                case 128098:
                    return 16778007;
                case 128099:
                    return 16778008;
                case 128100:
                    return 16778009;
                case 128101:
                    return 16778010;
                case 128102:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555227;
                        case 127996:
                            return 33555228;
                        case 127997:
                            return 33555229;
                        case 127998:
                            return 33555230;
                        case 127999:
                            return 33555231;
                        default:
                            return 16778016;
                    }
                case 128103:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555233;
                        case 127996:
                            return 33555234;
                        case 127997:
                            return 33555235;
                        case 127998:
                            return 33555236;
                        case 127999:
                            return 33555237;
                        default:
                            return 16778022;
                    }
                case 128104:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555259;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109688;
                                    case 9878:
                                        return 67109689;
                                    case 9992:
                                        return 67109690;
                                    case 127806:
                                        return 67109671;
                                    case 127859:
                                        return 67109672;
                                    case 127891:
                                        return 67109673;
                                    case 127908:
                                        return 67109674;
                                    case 127912:
                                        return 67109675;
                                    case 127979:
                                        return 67109676;
                                    case 127981:
                                        return 67109677;
                                    case 128187:
                                        return 67109678;
                                    case 128188:
                                        return 67109679;
                                    case 128295:
                                        return 67109680;
                                    case 128300:
                                        return 67109681;
                                    case 128640:
                                        return 67109682;
                                    case 128658:
                                        return 67109683;
                                    case 129456:
                                        return 67109684;
                                    case 129457:
                                        return 67109685;
                                    case 129458:
                                        return 67109686;
                                    case 129459:
                                        return 67109687;
                                    default:
                                        return 33555259;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555280;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109709;
                                    case 9878:
                                        return 67109710;
                                    case 9992:
                                        return 67109711;
                                    case 127806:
                                        return 67109692;
                                    case 127859:
                                        return 67109693;
                                    case 127891:
                                        return 67109694;
                                    case 127908:
                                        return 67109695;
                                    case 127912:
                                        return 67109696;
                                    case 127979:
                                        return 67109697;
                                    case 127981:
                                        return 67109698;
                                    case 128187:
                                        return 67109699;
                                    case 128188:
                                        return 67109700;
                                    case 128295:
                                        return 67109701;
                                    case 128300:
                                        return 67109702;
                                    case 128640:
                                        return 67109703;
                                    case 128658:
                                        return 67109704;
                                    case 129456:
                                        return 67109705;
                                    case 129457:
                                        return 67109706;
                                    case 129458:
                                        return 67109707;
                                    case 129459:
                                        return 67109708;
                                    default:
                                        return 33555280;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555301;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109730;
                                    case 9878:
                                        return 67109731;
                                    case 9992:
                                        return 67109732;
                                    case 127806:
                                        return 67109713;
                                    case 127859:
                                        return 67109714;
                                    case 127891:
                                        return 67109715;
                                    case 127908:
                                        return 67109716;
                                    case 127912:
                                        return 67109717;
                                    case 127979:
                                        return 67109718;
                                    case 127981:
                                        return 67109719;
                                    case 128187:
                                        return 67109720;
                                    case 128188:
                                        return 67109721;
                                    case 128295:
                                        return 67109722;
                                    case 128300:
                                        return 67109723;
                                    case 128640:
                                        return 67109724;
                                    case 128658:
                                        return 67109725;
                                    case 129456:
                                        return 67109726;
                                    case 129457:
                                        return 67109727;
                                    case 129458:
                                        return 67109728;
                                    case 129459:
                                        return 67109729;
                                    default:
                                        return 33555301;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555322;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109751;
                                    case 9878:
                                        return 67109752;
                                    case 9992:
                                        return 67109753;
                                    case 127806:
                                        return 67109734;
                                    case 127859:
                                        return 67109735;
                                    case 127891:
                                        return 67109736;
                                    case 127908:
                                        return 67109737;
                                    case 127912:
                                        return 67109738;
                                    case 127979:
                                        return 67109739;
                                    case 127981:
                                        return 67109740;
                                    case 128187:
                                        return 67109741;
                                    case 128188:
                                        return 67109742;
                                    case 128295:
                                        return 67109743;
                                    case 128300:
                                        return 67109744;
                                    case 128640:
                                        return 67109745;
                                    case 128658:
                                        return 67109746;
                                    case 129456:
                                        return 67109747;
                                    case 129457:
                                        return 67109748;
                                    case 129458:
                                        return 67109749;
                                    case 129459:
                                        return 67109750;
                                    default:
                                        return 33555322;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555343;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109772;
                                    case 9878:
                                        return 67109773;
                                    case 9992:
                                        return 67109774;
                                    case 127806:
                                        return 67109755;
                                    case 127859:
                                        return 67109756;
                                    case 127891:
                                        return 67109757;
                                    case 127908:
                                        return 67109758;
                                    case 127912:
                                        return 67109759;
                                    case 127979:
                                        return 67109760;
                                    case 127981:
                                        return 67109761;
                                    case 128187:
                                        return 67109762;
                                    case 128188:
                                        return 67109763;
                                    case 128295:
                                        return 67109764;
                                    case 128300:
                                        return 67109765;
                                    case 128640:
                                        return 67109766;
                                    case 128658:
                                        return 67109767;
                                    case 129456:
                                        return 67109768;
                                    case 129457:
                                        return 67109769;
                                    case 129458:
                                        return 67109770;
                                    case 129459:
                                        return 67109771;
                                    default:
                                        return 33555343;
                                }
                            default:
                                return 16778165;
                        }
                    }
                    switch (c0914b.next())
                    {
                        case 9877:
                            return 50332592;
                        case 9878:
                            return 50332593;
                        case 9992:
                            return 50332594;
                        case 10084:
                            if (c0914b.next() != 8205)
                            {
                                return 16778165;
                            }
                            next3 = c0914b.next();
                            if (next3 == 128104)
                            {
                                return 83887027;
                            }
                            if (next3 != 128139 || c0914b.next() != 8205)
                            {
                                return 16778165;
                            }
                            if (c0914b.next() == 128104)
                            {
                                i = 117441460;
                            }
                            return i;
                        case 127806:
                            return 50332560;
                        case 127859:
                            return 50332561;
                        case 127891:
                            return 50332562;
                        case 127908:
                            return 50332563;
                        case 127912:
                            return 50332564;
                        case 127979:
                            return 50332565;
                        case 127981:
                            return 50332566;
                        case 128102:
                            if (c0914b.next() != 8205)
                            {
                                return 50332568;
                            }
                            return c0914b.next() == 128102 ? 83886999 : 50332568;
                        case 128103:
                            if (c0914b.next() != 8205)
                            {
                                return 50332571;
                            }
                            switch (c0914b.next())
                            {
                                case 128102:
                                    return 83887001;
                                case 128103:
                                    return 83887002;
                                default:
                                    return 50332571;
                            }
                        case 128104:
                            if (c0914b.next() != 8205)
                            {
                                return 16778165;
                            }
                            switch (c0914b.next())
                            {
                                case 128102:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 83887005;
                                    }
                                    return c0914b.next() == 128102 ? 117441436 : 83887005;
                                case 128103:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 83887008;
                                    }
                                    switch (c0914b.next())
                                    {
                                        case 128102:
                                            return 117441438;
                                        case 128103:
                                            return 117441439;
                                        default:
                                            return 83887008;
                                    }
                                default:
                                    return 16778165;
                            }
                        case 128105:
                            if (c0914b.next() != 8205)
                            {
                                return 16778165;
                            }
                            switch (c0914b.next())
                            {
                                case 128102:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 83887010;
                                    }
                                    return c0914b.next() == 128102 ? 117441441 : 83887010;
                                case 128103:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 83887013;
                                    }
                                    switch (c0914b.next())
                                    {
                                        case 128102:
                                            return 117441443;
                                        case 128103:
                                            return 117441444;
                                        default:
                                            return 83887013;
                                    }
                                default:
                                    return 16778165;
                            }
                        case 128187:
                            return 50332582;
                        case 128188:
                            return 50332583;
                        case 128295:
                            return 50332584;
                        case 128300:
                            return 50332585;
                        case 128640:
                            return 50332586;
                        case 128658:
                            return 50332587;
                        case 129456:
                            return 50332588;
                        case 129457:
                            return 50332589;
                        case 129458:
                            return 50332590;
                        case 129459:
                            return 50332591;
                        default:
                            return 16778165;
                    }
                case 128105:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555402;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109831;
                                    case 9878:
                                        return 67109832;
                                    case 9992:
                                        return 67109833;
                                    case 127806:
                                        return 67109814;
                                    case 127859:
                                        return 67109815;
                                    case 127891:
                                        return 67109816;
                                    case 127908:
                                        return 67109817;
                                    case 127912:
                                        return 67109818;
                                    case 127979:
                                        return 67109819;
                                    case 127981:
                                        return 67109820;
                                    case 128187:
                                        return 67109821;
                                    case 128188:
                                        return 67109822;
                                    case 128295:
                                        return 67109823;
                                    case 128300:
                                        return 67109824;
                                    case 128640:
                                        return 67109825;
                                    case 128658:
                                        return 67109826;
                                    case 129456:
                                        return 67109827;
                                    case 129457:
                                        return 67109828;
                                    case 129458:
                                        return 67109829;
                                    case 129459:
                                        return 67109830;
                                    default:
                                        return 33555402;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555423;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109852;
                                    case 9878:
                                        return 67109853;
                                    case 9992:
                                        return 67109854;
                                    case 127806:
                                        return 67109835;
                                    case 127859:
                                        return 67109836;
                                    case 127891:
                                        return 67109837;
                                    case 127908:
                                        return 67109838;
                                    case 127912:
                                        return 67109839;
                                    case 127979:
                                        return 67109840;
                                    case 127981:
                                        return 67109841;
                                    case 128187:
                                        return 67109842;
                                    case 128188:
                                        return 67109843;
                                    case 128295:
                                        return 67109844;
                                    case 128300:
                                        return 67109845;
                                    case 128640:
                                        return 67109846;
                                    case 128658:
                                        return 67109847;
                                    case 129456:
                                        return 67109848;
                                    case 129457:
                                        return 67109849;
                                    case 129458:
                                        return 67109850;
                                    case 129459:
                                        return 67109851;
                                    default:
                                        return 33555423;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555444;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109873;
                                    case 9878:
                                        return 67109874;
                                    case 9992:
                                        return 67109875;
                                    case 127806:
                                        return 67109856;
                                    case 127859:
                                        return 67109857;
                                    case 127891:
                                        return 67109858;
                                    case 127908:
                                        return 67109859;
                                    case 127912:
                                        return 67109860;
                                    case 127979:
                                        return 67109861;
                                    case 127981:
                                        return 67109862;
                                    case 128187:
                                        return 67109863;
                                    case 128188:
                                        return 67109864;
                                    case 128295:
                                        return 67109865;
                                    case 128300:
                                        return 67109866;
                                    case 128640:
                                        return 67109867;
                                    case 128658:
                                        return 67109868;
                                    case 129456:
                                        return 67109869;
                                    case 129457:
                                        return 67109870;
                                    case 129458:
                                        return 67109871;
                                    case 129459:
                                        return 67109872;
                                    default:
                                        return 33555444;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555465;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109894;
                                    case 9878:
                                        return 67109895;
                                    case 9992:
                                        return 67109896;
                                    case 127806:
                                        return 67109877;
                                    case 127859:
                                        return 67109878;
                                    case 127891:
                                        return 67109879;
                                    case 127908:
                                        return 67109880;
                                    case 127912:
                                        return 67109881;
                                    case 127979:
                                        return 67109882;
                                    case 127981:
                                        return 67109883;
                                    case 128187:
                                        return 67109884;
                                    case 128188:
                                        return 67109885;
                                    case 128295:
                                        return 67109886;
                                    case 128300:
                                        return 67109887;
                                    case 128640:
                                        return 67109888;
                                    case 128658:
                                        return 67109889;
                                    case 129456:
                                        return 67109890;
                                    case 129457:
                                        return 67109891;
                                    case 129458:
                                        return 67109892;
                                    case 129459:
                                        return 67109893;
                                    default:
                                        return 33555465;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555486;
                                }
                                switch (c0914b.next())
                                {
                                    case 9877:
                                        return 67109915;
                                    case 9878:
                                        return 67109916;
                                    case 9992:
                                        return 67109917;
                                    case 127806:
                                        return 67109898;
                                    case 127859:
                                        return 67109899;
                                    case 127891:
                                        return 67109900;
                                    case 127908:
                                        return 67109901;
                                    case 127912:
                                        return 67109902;
                                    case 127979:
                                        return 67109903;
                                    case 127981:
                                        return 67109904;
                                    case 128187:
                                        return 67109905;
                                    case 128188:
                                        return 67109906;
                                    case 128295:
                                        return 67109907;
                                    case 128300:
                                        return 67109908;
                                    case 128640:
                                        return 67109909;
                                    case 128658:
                                        return 67109910;
                                    case 129456:
                                        return 67109911;
                                    case 129457:
                                        return 67109912;
                                    case 129458:
                                        return 67109913;
                                    case 129459:
                                        return 67109914;
                                    default:
                                        return 33555486;
                                }
                            default:
                                return 16778305;
                        }
                    }
                    switch (c0914b.next())
                    {
                        case 9877:
                            return 50332730;
                        case 9878:
                            return 50332731;
                        case 9992:
                            return 50332732;
                        case 10084:
                            if (c0914b.next() != 8205)
                            {
                                return 16778305;
                            }
                            switch (c0914b.next())
                            {
                                case 128104:
                                    return 83887165;
                                case 128105:
                                    return 83887166;
                                case 128139:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 16778305;
                                    }
                                    switch (c0914b.next())
                                    {
                                        case 128104:
                                            return 117441599;
                                        case 128105:
                                            return 117441600;
                                        default:
                                            return 16778305;
                                    }
                                default:
                                    return 16778305;
                            }
                        case 127806:
                            return 50332703;
                        case 127859:
                            return 50332704;
                        case 127891:
                            return 50332705;
                        case 127908:
                            return 50332706;
                        case 127912:
                            return 50332707;
                        case 127979:
                            return 50332708;
                        case 127981:
                            return 50332709;
                        case 128102:
                            if (c0914b.next() != 8205)
                            {
                                return 50332711;
                            }
                            return c0914b.next() == 128102 ? 83887142 : 50332711;
                        case 128103:
                            if (c0914b.next() != 8205)
                            {
                                return 50332714;
                            }
                            switch (c0914b.next())
                            {
                                case 128102:
                                    return 83887144;
                                case 128103:
                                    return 83887145;
                                default:
                                    return 50332714;
                            }
                        case 128105:
                            if (c0914b.next() != 8205)
                            {
                                return 16778305;
                            }
                            switch (c0914b.next())
                            {
                                case 128102:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 83887148;
                                    }
                                    return c0914b.next() == 128102 ? 117441579 : 83887148;
                                case 128103:
                                    if (c0914b.next() != 8205)
                                    {
                                        return 83887151;
                                    }
                                    switch (c0914b.next())
                                    {
                                        case 128102:
                                            return 117441581;
                                        case 128103:
                                            return 117441582;
                                        default:
                                            return 83887151;
                                    }
                                default:
                                    return 16778305;
                            }
                        case 128187:
                            return 50332720;
                        case 128188:
                            return 50332721;
                        case 128295:
                            return 50332722;
                        case 128300:
                            return 50332723;
                        case 128640:
                            return 50332724;
                        case 128658:
                            return 50332725;
                        case 129456:
                            return 50332726;
                        case 129457:
                            return 50332727;
                        case 129458:
                            return 50332728;
                        case 129459:
                            return 50332729;
                        default:
                            return 16778305;
                    }
                case 128106:
                    return 16778306;
                case 128107:
                    return 16778307;
                case 128108:
                    return 16778308;
                case 128109:
                    return 16778309;
                case 128110:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555527;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555527 : 67109959;
                                }
                                else
                                {
                                    return 67109958;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555529;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555529 : 67109961;
                                }
                                else
                                {
                                    return 67109960;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555531;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555531 : 67109963;
                                }
                                else
                                {
                                    return 67109962;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555533;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555533 : 67109965;
                                }
                                else
                                {
                                    return 67109964;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555535;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555535 : 67109967;
                                }
                                else
                                {
                                    return 67109966;
                                }
                            default:
                                return 16778321;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 == 9792)
                    {
                        return 50332752;
                    }
                    if (next2 != 9794)
                    {
                        return 16778321;
                    }
                    return 50332753;
                case 128111:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555538;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555538 : 67109971;
                                }
                                else
                                {
                                    return 67109970;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555540;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555540 : 67109973;
                                }
                                else
                                {
                                    return 67109972;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555542;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555542 : 67109975;
                                }
                                else
                                {
                                    return 67109974;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555544;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555544 : 67109977;
                                }
                                else
                                {
                                    return 67109976;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555546;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555546 : 67109979;
                                }
                                else
                                {
                                    return 67109978;
                                }
                            default:
                                return 16778332;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778332 : 50332765;
                    }
                    else
                    {
                        return 50332764;
                    }
                case 128112:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555550;
                        case 127996:
                            return 33555551;
                        case 127997:
                            return 33555552;
                        case 127998:
                            return 33555553;
                        case 127999:
                            return 33555554;
                        default:
                            return 16778339;
                    }
                case 128113:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555557;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555557 : 67109989;
                                }
                                else
                                {
                                    return 67109988;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555559;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555559 : 67109991;
                                }
                                else
                                {
                                    return 67109990;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555561;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555561 : 67109993;
                                }
                                else
                                {
                                    return 67109992;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555563;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555563 : 67109995;
                                }
                                else
                                {
                                    return 67109994;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555565;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555565 : 67109997;
                                }
                                else
                                {
                                    return 67109996;
                                }
                            default:
                                return 16778351;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778351 : 50332783;
                    }
                    else
                    {
                        return 50332782;
                    }
                case 128114:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555568;
                        case 127996:
                            return 33555569;
                        case 127997:
                            return 33555570;
                        case 127998:
                            return 33555571;
                        case 127999:
                            return 33555572;
                        default:
                            return 16778357;
                    }
                case 128115:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555575;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555575 : 67110007;
                                }
                                else
                                {
                                    return 67110006;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555577;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555577 : 67110009;
                                }
                                else
                                {
                                    return 67110008;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555579;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555579 : 67110011;
                                }
                                else
                                {
                                    return 67110010;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555581;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555581 : 67110013;
                                }
                                else
                                {
                                    return 67110012;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555583;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555583 : 67110015;
                                }
                                else
                                {
                                    return 67110014;
                                }
                            default:
                                return 16778369;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778369 : 50332801;
                    }
                    else
                    {
                        return 50332800;
                    }
                case 128116:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555586;
                        case 127996:
                            return 33555587;
                        case 127997:
                            return 33555588;
                        case 127998:
                            return 33555589;
                        case 127999:
                            return 33555590;
                        default:
                            return 16778375;
                    }
                case 128117:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555592;
                        case 127996:
                            return 33555593;
                        case 127997:
                            return 33555594;
                        case 127998:
                            return 33555595;
                        case 127999:
                            return 33555596;
                        default:
                            return 16778381;
                    }
                case 128118:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555598;
                        case 127996:
                            return 33555599;
                        case 127997:
                            return 33555600;
                        case 127998:
                            return 33555601;
                        case 127999:
                            return 33555602;
                        default:
                            return 16778387;
                    }
                case 128119:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555605;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555605 : 67110037;
                                }
                                else
                                {
                                    return 67110036;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555607;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555607 : 67110039;
                                }
                                else
                                {
                                    return 67110038;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555609;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555609 : 67110041;
                                }
                                else
                                {
                                    return 67110040;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555611;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555611 : 67110043;
                                }
                                else
                                {
                                    return 67110042;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555613;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555613 : 67110045;
                                }
                                else
                                {
                                    return 67110044;
                                }
                            default:
                                return 16778399;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778399 : 50332831;
                    }
                    else
                    {
                        return 50332830;
                    }
                case 128120:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555616;
                        case 127996:
                            return 33555617;
                        case 127997:
                            return 33555618;
                        case 127998:
                            return 33555619;
                        case 127999:
                            return 33555620;
                        default:
                            return 16778405;
                    }
                case 128121:
                    return 16778406;
                case 128122:
                    return 16778407;
                case 128123:
                    return 16778408;
                case 128124:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555625;
                        case 127996:
                            return 33555626;
                        case 127997:
                            return 33555627;
                        case 127998:
                            return 33555628;
                        case 127999:
                            return 33555629;
                        default:
                            return 16778414;
                    }
                case 128125:
                    return 16778415;
                case 128126:
                    return 16778416;
                case 128127:
                    return 16778417;
                case 128128:
                    return 16778418;
                case 128129:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555635;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555635 : 67110068;
                                }
                                else
                                {
                                    return 67110067;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555637;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555637 : 67110070;
                                }
                                else
                                {
                                    return 67110069;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555639;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555639 : 67110072;
                                }
                                else
                                {
                                    return 67110071;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555641;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555641 : 67110074;
                                }
                                else
                                {
                                    return 67110073;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555643;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555643 : 67110076;
                                }
                                else
                                {
                                    return 67110075;
                                }
                            default:
                                return 16778429;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778429 : 50332862;
                    }
                    else
                    {
                        return 50332861;
                    }
                case 128130:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555648;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555648 : 67110080;
                                }
                                else
                                {
                                    return 67110079;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555650;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555650 : 67110082;
                                }
                                else
                                {
                                    return 67110081;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555652;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555652 : 67110084;
                                }
                                else
                                {
                                    return 67110083;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555654;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555654 : 67110086;
                                }
                                else
                                {
                                    return 67110085;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555656;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555656 : 67110088;
                                }
                                else
                                {
                                    return 67110087;
                                }
                            default:
                                return 16778442;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778442 : 50332874;
                    }
                    else
                    {
                        return 50332873;
                    }
                case 128131:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555659;
                        case 127996:
                            return 33555660;
                        case 127997:
                            return 33555661;
                        case 127998:
                            return 33555662;
                        case 127999:
                            return 33555663;
                        default:
                            return 16778448;
                    }
                case 128132:
                    return 16778449;
                case 128133:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555666;
                        case 127996:
                            return 33555667;
                        case 127997:
                            return 33555668;
                        case 127998:
                            return 33555669;
                        case 127999:
                            return 33555670;
                        default:
                            return 16778455;
                    }
                case 128134:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555672;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555672 : 67110105;
                                }
                                else
                                {
                                    return 67110104;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555674;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555674 : 67110107;
                                }
                                else
                                {
                                    return 67110106;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555676;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555676 : 67110109;
                                }
                                else
                                {
                                    return 67110108;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555678;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555678 : 67110111;
                                }
                                else
                                {
                                    return 67110110;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555680;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555680 : 67110113;
                                }
                                else
                                {
                                    return 67110112;
                                }
                            default:
                                return 16778466;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778466 : 50332899;
                    }
                    else
                    {
                        return 50332898;
                    }
                case 128135:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555684;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555684 : 67110117;
                                }
                                else
                                {
                                    return 67110116;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555686;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555686 : 67110119;
                                }
                                else
                                {
                                    return 67110118;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555688;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555688 : 67110121;
                                }
                                else
                                {
                                    return 67110120;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555690;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555690 : 67110123;
                                }
                                else
                                {
                                    return 67110122;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555692;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555692 : 67110125;
                                }
                                else
                                {
                                    return 67110124;
                                }
                            default:
                                return 16778478;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778478 : 50332911;
                    }
                    else
                    {
                        return 50332910;
                    }
                case 128136:
                    return 16778480;
                case 128137:
                    return 16778481;
                case 128138:
                    return 16778482;
                case 128139:
                    return 16778483;
                case 128140:
                    return 16778484;
                case 128141:
                    return 16778485;
                case 128142:
                    return 16778486;
                case 128143:
                    return 16778487;
                case 128144:
                    return 16778488;
                case 128145:
                    return 16778489;
                case 128146:
                    return 16778490;
                case 128147:
                    return 16778491;
                case 128148:
                    return 16778492;
                case 128149:
                    return 16778493;
                case 128150:
                    return 16778494;
                case 128151:
                    return 16778495;
                case 128152:
                    return 16778496;
                case 128153:
                    return 16778497;
                case 128154:
                    return 16778498;
                case 128155:
                    return 16778499;
                case 128156:
                    return 16778500;
                case 128157:
                    return 16778501;
                case 128158:
                    return 16778502;
                case 128159:
                    return 16778503;
                case 128160:
                    return 16778504;
                case 128161:
                    return 16778505;
                case 128162:
                    return 16778506;
                case 128163:
                    return 16778507;
                case 128164:
                    return 16778508;
                case 128165:
                    return 16778509;
                case 128166:
                    return 16778510;
                case 128167:
                    return 16778511;
                case 128168:
                    return 16778512;
                case 128169:
                    return 16778513;
                case 128170:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555730;
                        case 127996:
                            return 33555731;
                        case 127997:
                            return 33555732;
                        case 127998:
                            return 33555733;
                        case 127999:
                            return 33555734;
                        default:
                            return 16778519;
                    }
                case 128171:
                    return 16778520;
                case 128172:
                    return 16778521;
                case 128173:
                    return 16778522;
                case 128174:
                    return 16778523;
                case 128175:
                    return 16778524;
                case 128176:
                    return 16778525;
                case 128177:
                    return 16778526;
                case 128178:
                    return 16778527;
                case 128179:
                    return 16778528;
                case 128180:
                    return 16778529;
                case 128181:
                    return 16778530;
                case 128182:
                    return 16778531;
                case 128183:
                    return 16778532;
                case 128184:
                    return 16778533;
                case 128185:
                    return 16778534;
                case 128186:
                    return 16778535;
                case 128187:
                    return 16778536;
                case 128188:
                    return 16778537;
                case 128189:
                    return 16778538;
                case 128190:
                    return 16778539;
                case 128191:
                    return 16778540;
                case 128192:
                    return 16778541;
                case 128193:
                    return 16778542;
                case 128194:
                    return 16778543;
                case 128195:
                    return 16778544;
                case 128196:
                    return 16778545;
                case 128197:
                    return 16778546;
                case 128198:
                    return 16778547;
                case 128199:
                    return 16778548;
                case 128200:
                    return 16778549;
                case 128201:
                    return 16778550;
                case 128202:
                    return 16778551;
                case 128203:
                    return 16778552;
                case 128204:
                    return 16778553;
                case 128205:
                    return 16778554;
                case 128206:
                    return 16778555;
                case 128207:
                    return 16778556;
                case 128208:
                    return 16778557;
                case 128209:
                    return 16778558;
                case 128210:
                    return 16778559;
                case 128211:
                    return 16778560;
                case 128212:
                    return 16778561;
                case 128213:
                    return 16778562;
                case 128214:
                    return 16778563;
                case 128215:
                    return 16778564;
                case 128216:
                    return 16778565;
                case 128217:
                    return 16778566;
                case 128218:
                    return 16778567;
                case 128219:
                    return 16778568;
                case 128220:
                    return 16778569;
                case 128221:
                    return 16778570;
                case 128222:
                    return 16778571;
                case 128223:
                    return 16778572;
                case 128224:
                    return 16778573;
                case 128225:
                    return 16778574;
                case 128226:
                    return 16778575;
                case 128227:
                    return 16778576;
                case 128228:
                    return 16778577;
                case 128229:
                    return 16778578;
                case 128230:
                    return 16778579;
                case 128231:
                    return 16778580;
                case 128232:
                    return 16778581;
                case 128233:
                    return 16778582;
                case 128234:
                    return 16778583;
                case 128235:
                    return 16778584;
                case 128236:
                    return 16778585;
                case 128237:
                    return 16778586;
                case 128238:
                    return 16778587;
                case 128239:
                    return 16778588;
                case 128240:
                    return 16778589;
                case 128241:
                    return 16778590;
                case 128242:
                    return 16778591;
                case 128243:
                    return 16778592;
                case 128244:
                    return 16778593;
                case 128245:
                    return 16778594;
                case 128246:
                    return 16778595;
                case 128247:
                    return 16778596;
                case 128248:
                    return 16778597;
                case 128249:
                    return 16778598;
                case 128250:
                    return 16778599;
                case 128251:
                    return 16778600;
                case 128252:
                    return 16778601;
                case 128253:
                    return 16778602;
                case 128255:
                    return 16778603;
                case 128256:
                    return 16778604;
                case 128257:
                    return 16778605;
                case 128258:
                    return 16778606;
                case 128259:
                    return 16778607;
                case 128260:
                    return 16778608;
                case 128261:
                    return 16778609;
                case 128262:
                    return 16778610;
                case 128263:
                    return 16778611;
                case 128264:
                    return 16778612;
                case 128265:
                    return 16778613;
                case 128266:
                    return 16778614;
                case 128267:
                    return 16778615;
                case 128268:
                    return 16778616;
                case 128269:
                    return 16778617;
                case 128270:
                    return 16778618;
                case 128271:
                    return 16778619;
                case 128272:
                    return 16778620;
                case 128273:
                    return 16778621;
                case 128274:
                    return 16778622;
                case 128275:
                    return 16778623;
                case 128276:
                    return 16778624;
                case 128277:
                    return 16778625;
                case 128278:
                    return 16778626;
                case 128279:
                    return 16778627;
                case 128280:
                    return 16778628;
                case 128281:
                    return 16778629;
                case 128282:
                    return 16778630;
                case 128283:
                    return 16778631;
                case 128284:
                    return 16778632;
                case 128285:
                    return 16778633;
                case 128286:
                    return 16778634;
                case 128287:
                    return 16778635;
                case 128288:
                    return 16778636;
                case 128289:
                    return 16778637;
                case 128290:
                    return 16778638;
                case 128291:
                    return 16778639;
                case 128292:
                    return 16778640;
                case 128293:
                    return 16778641;
                case 128294:
                    return 16778642;
                case 128295:
                    return 16778643;
                case 128296:
                    return 16778644;
                case 128297:
                    return 16778645;
                case 128298:
                    return 16778646;
                case 128299:
                    return 16778647;
                case 128300:
                    return 16778648;
                case 128301:
                    return 16778649;
                case 128302:
                    return 16778650;
                case 128303:
                    return 16778651;
                case 128304:
                    return 16778652;
                case 128305:
                    return 16778653;
                case 128306:
                    return 16778654;
                case 128307:
                    return 16778655;
                case 128308:
                    return 16778656;
                case 128309:
                    return 16778657;
                case 128310:
                    return 16778658;
                case 128311:
                    return 16778659;
                case 128312:
                    return 16778660;
                case 128313:
                    return 16778661;
                case 128314:
                    return 16778662;
                case 128315:
                    return 16778663;
                case 128316:
                    return 16778664;
                case 128317:
                    return 16778665;
                case 128329:
                    return 16778666;
                case 128330:
                    return 16778667;
                case 128331:
                    return 16778668;
                case 128332:
                    return 16778669;
                case 128333:
                    return 16778670;
                case 128334:
                    return 16778671;
                case 128336:
                    return 16778672;
                case 128337:
                    return 16778673;
                case 128338:
                    return 16778674;
                case 128339:
                    return 16778675;
                case 128340:
                    return 16778676;
                case 128341:
                    return 16778677;
                case 128342:
                    return 16778678;
                case 128343:
                    return 16778679;
                case 128344:
                    return 16778680;
                case 128345:
                    return 16778681;
                case 128346:
                    return 16778682;
                case 128347:
                    return 16778683;
                case 128348:
                    return 16778684;
                case 128349:
                    return 16778685;
                case 128350:
                    return 16778686;
                case 128351:
                    return 16778687;
                case 128352:
                    return 16778688;
                case 128353:
                    return 16778689;
                case 128354:
                    return 16778690;
                case 128355:
                    return 16778691;
                case 128356:
                    return 16778692;
                case 128357:
                    return 16778693;
                case 128358:
                    return 16778694;
                case 128359:
                    return 16778695;
                case 128367:
                    return 16778696;
                case 128368:
                    return 16778697;
                case 128371:
                    return 16778698;
                case 128372:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555915;
                        case 127996:
                            return 33555916;
                        case 127997:
                            return 33555917;
                        case 127998:
                            return 33555918;
                        case 127999:
                            return 33555919;
                        default:
                            return 16778704;
                    }
                case 128373:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555922;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555922 : 67110354;
                                }
                                else
                                {
                                    return 67110353;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555924;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555924 : 67110356;
                                }
                                else
                                {
                                    return 67110355;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555926;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555926 : 67110358;
                                }
                                else
                                {
                                    return 67110357;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555928;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555928 : 67110360;
                                }
                                else
                                {
                                    return 67110359;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33555930;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33555930 : 67110362;
                                }
                                else
                                {
                                    return 67110361;
                                }
                            default:
                                return 16778716;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778716 : 50333148;
                    }
                    else
                    {
                        return 50333147;
                    }
                case 128374:
                    return 16778717;
                case 128375:
                    return 16778718;
                case 128376:
                    return 16778719;
                case 128377:
                    return 16778720;
                case 128378:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555937;
                        case 127996:
                            return 33555938;
                        case 127997:
                            return 33555939;
                        case 127998:
                            return 33555940;
                        case 127999:
                            return 33555941;
                        default:
                            return 16778726;
                    }
                case 128391:
                    return 16778727;
                case 128394:
                    return 16778728;
                case 128395:
                    return 16778729;
                case 128396:
                    return 16778730;
                case 128397:
                    return 16778731;
                case 128400:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555948;
                        case 127996:
                            return 33555949;
                        case 127997:
                            return 33555950;
                        case 127998:
                            return 33555951;
                        case 127999:
                            return 33555952;
                        default:
                            return 16778737;
                    }
                case 128405:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555954;
                        case 127996:
                            return 33555955;
                        case 127997:
                            return 33555956;
                        case 127998:
                            return 33555957;
                        case 127999:
                            return 33555958;
                        default:
                            return 16778743;
                    }
                case 128406:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33555960;
                        case 127996:
                            return 33555961;
                        case 127997:
                            return 33555962;
                        case 127998:
                            return 33555963;
                        case 127999:
                            return 33555964;
                        default:
                            return 16778749;
                    }
                case 128420:
                    return 16778750;
                case 128421:
                    return 16778751;
                case 128424:
                    return 16778752;
                case 128433:
                    return 16778753;
                case 128434:
                    return 16778754;
                case 128444:
                    return 16778755;
                case 128450:
                    return 16778756;
                case 128451:
                    return 16778757;
                case 128452:
                    return 16778758;
                case 128465:
                    return 16778759;
                case 128466:
                    return 16778760;
                case 128467:
                    return 16778761;
                case 128476:
                    return 16778762;
                case 128477:
                    return 16778763;
                case 128478:
                    return 16778764;
                case 128481:
                    return 16778765;
                case 128483:
                    return 16778766;
                case 128488:
                    return 16778767;
                case 128495:
                    return 16778768;
                case 128499:
                    return 16778769;
                case 128506:
                    return 16778770;
                case 128507:
                    return 16778771;
                case 128508:
                    return 16778772;
                case 128509:
                    return 16778773;
                case 128510:
                    return 16778774;
                case 128511:
                    return 16778775;
                case 128512:
                    return 16778776;
                case 128513:
                    return 16778777;
                case 128514:
                    return 16778778;
                case 128515:
                    return 16778779;
                case 128516:
                    return 16778780;
                case 128517:
                    return 16778781;
                case 128518:
                    return 16778782;
                case 128519:
                    return 16778783;
                case 128520:
                    return 16778784;
                case 128521:
                    return 16778785;
                case 128522:
                    return 16778786;
                case 128523:
                    return 16778787;
                case 128524:
                    return 16778788;
                case 128525:
                    return 16778789;
                case 128526:
                    return 16778790;
                case 128527:
                    return 16778791;
                case 128528:
                    return 16778792;
                case 128529:
                    return 16778793;
                case 128530:
                    return 16778794;
                case 128531:
                    return 16778795;
                case 128532:
                    return 16778796;
                case 128533:
                    return 16778797;
                case 128534:
                    return 16778798;
                case 128535:
                    return 16778799;
                case 128536:
                    return 16778800;
                case 128537:
                    return 16778801;
                case 128538:
                    return 16778802;
                case 128539:
                    return 16778803;
                case 128540:
                    return 16778804;
                case 128541:
                    return 16778805;
                case 128542:
                    return 16778806;
                case 128543:
                    return 16778807;
                case 128544:
                    return 16778808;
                case 128545:
                    return 16778809;
                case 128546:
                    return 16778810;
                case 128547:
                    return 16778811;
                case 128548:
                    return 16778812;
                case 128549:
                    return 16778813;
                case 128550:
                    return 16778814;
                case 128551:
                    return 16778815;
                case 128552:
                    return 16778816;
                case 128553:
                    return 16778817;
                case 128554:
                    return 16778818;
                case 128555:
                    return 16778819;
                case 128556:
                    return 16778820;
                case 128557:
                    return 16778821;
                case 128558:
                    return 16778822;
                case 128559:
                    return 16778823;
                case 128560:
                    return 16778824;
                case 128561:
                    return 16778825;
                case 128562:
                    return 16778826;
                case 128563:
                    return 16778827;
                case 128564:
                    return 16778828;
                case 128565:
                    return 16778829;
                case 128566:
                    return 16778830;
                case 128567:
                    return 16778831;
                case 128568:
                    return 16778832;
                case 128569:
                    return 16778833;
                case 128570:
                    return 16778834;
                case 128571:
                    return 16778835;
                case 128572:
                    return 16778836;
                case 128573:
                    return 16778837;
                case 128574:
                    return 16778838;
                case 128575:
                    return 16778839;
                case 128576:
                    return 16778840;
                case 128577:
                    return 16778841;
                case 128578:
                    return 16778842;
                case 128579:
                    return 16778843;
                case 128580:
                    return 16778844;
                case 128581:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556061;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556061 : 67110494;
                                }
                                else
                                {
                                    return 67110493;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556063;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556063 : 67110496;
                                }
                                else
                                {
                                    return 67110495;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556065;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556065 : 67110498;
                                }
                                else
                                {
                                    return 67110497;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556067;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556067 : 67110500;
                                }
                                else
                                {
                                    return 67110499;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556069;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556069 : 67110502;
                                }
                                else
                                {
                                    return 67110501;
                                }
                            default:
                                return 16778855;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778855 : 50333288;
                    }
                    else
                    {
                        return 50333287;
                    }
                case 128582:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556073;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556073 : 67110506;
                                }
                                else
                                {
                                    return 67110505;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556075;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556075 : 67110508;
                                }
                                else
                                {
                                    return 67110507;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556077;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556077 : 67110510;
                                }
                                else
                                {
                                    return 67110509;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556079;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556079 : 67110512;
                                }
                                else
                                {
                                    return 67110511;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556081;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556081 : 67110514;
                                }
                                else
                                {
                                    return 67110513;
                                }
                            default:
                                return 16778867;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778867 : 50333300;
                    }
                    else
                    {
                        return 50333299;
                    }
                case 128583:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556086;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556086 : 67110518;
                                }
                                else
                                {
                                    return 67110517;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556088;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556088 : 67110520;
                                }
                                else
                                {
                                    return 67110519;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556090;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556090 : 67110522;
                                }
                                else
                                {
                                    return 67110521;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556092;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556092 : 67110524;
                                }
                                else
                                {
                                    return 67110523;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556094;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556094 : 67110526;
                                }
                                else
                                {
                                    return 67110525;
                                }
                            default:
                                return 16778880;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778880 : 50333312;
                    }
                    else
                    {
                        return 50333311;
                    }
                case 128584:
                    return 16778881;
                case 128585:
                    return 16778882;
                case 128586:
                    return 16778883;
                case 128587:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556100;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556100 : 67110533;
                                }
                                else
                                {
                                    return 67110532;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556102;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556102 : 67110535;
                                }
                                else
                                {
                                    return 67110534;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556104;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556104 : 67110537;
                                }
                                else
                                {
                                    return 67110536;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556106;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556106 : 67110539;
                                }
                                else
                                {
                                    return 67110538;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556108;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556108 : 67110541;
                                }
                                else
                                {
                                    return 67110540;
                                }
                            default:
                                return 16778894;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778894 : 50333327;
                    }
                    else
                    {
                        return 50333326;
                    }
                case 128588:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556112;
                        case 127996:
                            return 33556113;
                        case 127997:
                            return 33556114;
                        case 127998:
                            return 33556115;
                        case 127999:
                            return 33556116;
                        default:
                            return 16778901;
                    }
                case 128589:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556118;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556118 : 67110551;
                                }
                                else
                                {
                                    return 67110550;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556120;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556120 : 67110553;
                                }
                                else
                                {
                                    return 67110552;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556122;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556122 : 67110555;
                                }
                                else
                                {
                                    return 67110554;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556124;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556124 : 67110557;
                                }
                                else
                                {
                                    return 67110556;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556126;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556126 : 67110559;
                                }
                                else
                                {
                                    return 67110558;
                                }
                            default:
                                return 16778912;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778912 : 50333345;
                    }
                    else
                    {
                        return 50333344;
                    }
                case 128590:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556130;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556130 : 67110563;
                                }
                                else
                                {
                                    return 67110562;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556132;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556132 : 67110565;
                                }
                                else
                                {
                                    return 67110564;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556134;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556134 : 67110567;
                                }
                                else
                                {
                                    return 67110566;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556136;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556136 : 67110569;
                                }
                                else
                                {
                                    return 67110568;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556138;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556138 : 67110571;
                                }
                                else
                                {
                                    return 67110570;
                                }
                            default:
                                return 16778924;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778924 : 50333357;
                    }
                    else
                    {
                        return 50333356;
                    }
                case 128591:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556142;
                        case 127996:
                            return 33556143;
                        case 127997:
                            return 33556144;
                        case 127998:
                            return 33556145;
                        case 127999:
                            return 33556146;
                        default:
                            return 16778931;
                    }
                case 128640:
                    return 16778932;
                case 128641:
                    return 16778933;
                case 128642:
                    return 16778934;
                case 128643:
                    return 16778935;
                case 128644:
                    return 16778936;
                case 128645:
                    return 16778937;
                case 128646:
                    return 16778938;
                case 128647:
                    return 16778939;
                case 128648:
                    return 16778940;
                case 128649:
                    return 16778941;
                case 128650:
                    return 16778942;
                case 128651:
                    return 16778943;
                case 128652:
                    return 16778944;
                case 128653:
                    return 16778945;
                case 128654:
                    return 16778946;
                case 128655:
                    return 16778947;
                case 128656:
                    return 16778948;
                case 128657:
                    return 16778949;
                case 128658:
                    return 16778950;
                case 128659:
                    return 16778951;
                case 128660:
                    return 16778952;
                case 128661:
                    return 16778953;
                case 128662:
                    return 16778954;
                case 128663:
                    return 16778955;
                case 128664:
                    return 16778956;
                case 128665:
                    return 16778957;
                case 128666:
                    return 16778958;
                case 128667:
                    return 16778959;
                case 128668:
                    return 16778960;
                case 128669:
                    return 16778961;
                case 128670:
                    return 16778962;
                case 128671:
                    return 16778963;
                case 128672:
                    return 16778964;
                case 128673:
                    return 16778965;
                case 128674:
                    return 16778966;
                case 128675:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556184;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556184 : 67110616;
                                }
                                else
                                {
                                    return 67110615;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556186;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556186 : 67110618;
                                }
                                else
                                {
                                    return 67110617;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556188;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556188 : 67110620;
                                }
                                else
                                {
                                    return 67110619;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556190;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556190 : 67110622;
                                }
                                else
                                {
                                    return 67110621;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556192;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556192 : 67110624;
                                }
                                else
                                {
                                    return 67110623;
                                }
                            default:
                                return 16778979;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16778979 : 50333410;
                    }
                    else
                    {
                        return 50333409;
                    }
                case 128676:
                    return 16778980;
                case 128677:
                    return 16778981;
                case 128678:
                    return 16778982;
                case 128679:
                    return 16778983;
                case 128680:
                    return 16778984;
                case 128681:
                    return 16778985;
                case 128682:
                    return 16778986;
                case 128683:
                    return 16778987;
                case 128684:
                    return 16778988;
                case 128685:
                    return 16778989;
                case 128686:
                    return 16778990;
                case 128687:
                    return 16778991;
                case 128688:
                    return 16778992;
                case 128689:
                    return 16778993;
                case 128690:
                    return 16778994;
                case 128691:
                    return 16778995;
                case 128692:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556213;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556213 : 67110645;
                                }
                                else
                                {
                                    return 67110644;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556215;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556215 : 67110647;
                                }
                                else
                                {
                                    return 67110646;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556217;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556217 : 67110649;
                                }
                                else
                                {
                                    return 67110648;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556219;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556219 : 67110651;
                                }
                                else
                                {
                                    return 67110650;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556221;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556221 : 67110653;
                                }
                                else
                                {
                                    return 67110652;
                                }
                            default:
                                return 16779008;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779008 : 50333439;
                    }
                    else
                    {
                        return 50333438;
                    }
                case 128693:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556226;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556226 : 67110658;
                                }
                                else
                                {
                                    return 67110657;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556228;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556228 : 67110660;
                                }
                                else
                                {
                                    return 67110659;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556230;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556230 : 67110662;
                                }
                                else
                                {
                                    return 67110661;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556232;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556232 : 67110664;
                                }
                                else
                                {
                                    return 67110663;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556234;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556234 : 67110666;
                                }
                                else
                                {
                                    return 67110665;
                                }
                            default:
                                return 16779021;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779021 : 50333452;
                    }
                    else
                    {
                        return 50333451;
                    }
                case 128694:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556239;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556239 : 67110671;
                                }
                                else
                                {
                                    return 67110670;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556241;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556241 : 67110673;
                                }
                                else
                                {
                                    return 67110672;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556243;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556243 : 67110675;
                                }
                                else
                                {
                                    return 67110674;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556245;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556245 : 67110677;
                                }
                                else
                                {
                                    return 67110676;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556247;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556247 : 67110679;
                                }
                                else
                                {
                                    return 67110678;
                                }
                            default:
                                return 16779034;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 == 9792)
                    {
                        return 50333464;
                    }
                    if (next2 != 9794)
                    {
                        return 16779034;
                    }
                    return 50333465;
                case 128695:
                    return 16779035;
                case 128696:
                    return 16779036;
                case 128697:
                    return 16779037;
                case 128698:
                    return 16779038;
                case 128699:
                    return 16779039;
                case 128700:
                    return 16779040;
                case 128701:
                    return 16779041;
                case 128702:
                    return 16779042;
                case 128703:
                    return 16779043;
                case 128704:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556260;
                        case 127996:
                            return 33556261;
                        case 127997:
                            return 33556262;
                        case 127998:
                            return 33556263;
                        case 127999:
                            return 33556264;
                        default:
                            return 16779049;
                    }
                case 128705:
                    return 16779050;
                case 128706:
                    return 16779051;
                case 128707:
                    return 16779052;
                case 128708:
                    return 16779053;
                case 128709:
                    return 16779054;
                case 128715:
                    return 16779055;
                case 128716:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556272;
                        case 127996:
                            return 33556273;
                        case 127997:
                            return 33556274;
                        case 127998:
                            return 33556275;
                        case 127999:
                            return 33556276;
                        default:
                            return 16779061;
                    }
                case 128717:
                    return 16779062;
                case 128718:
                    return 16779063;
                case 128719:
                    return 16779064;
                case 128720:
                    return 16779065;
                case 128721:
                    return 16779066;
                case 128722:
                    return 16779067;
                case 128736:
                    return 16779068;
                case 128737:
                    return 16779069;
                case 128738:
                    return 16779070;
                case 128739:
                    return 16779071;
                case 128740:
                    return 16779072;
                case 128741:
                    return 16779073;
                case 128745:
                    return 16779074;
                case 128747:
                    return 16779075;
                case 128748:
                    return 16779076;
                case 128752:
                    return 16779077;
                case 128755:
                    return 16779078;
                case 128756:
                    return 16779079;
                case 128757:
                    return 16779080;
                case 128758:
                    return 16779081;
                case 128759:
                    return 16779082;
                case 128760:
                    return 16779083;
                case 128761:
                    return 16779084;
                case 129296:
                    return 16779085;
                case 129297:
                    return 16779086;
                case 129298:
                    return 16779087;
                case 129299:
                    return 16779088;
                case 129300:
                    return 16779089;
                case 129301:
                    return 16779090;
                case 129302:
                    return 16779091;
                case 129303:
                    return 16779092;
                case 129304:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556309;
                        case 127996:
                            return 33556310;
                        case 127997:
                            return 33556311;
                        case 127998:
                            return 33556312;
                        case 127999:
                            return 33556313;
                        default:
                            return 16779098;
                    }
                case 129305:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556315;
                        case 127996:
                            return 33556316;
                        case 127997:
                            return 33556317;
                        case 127998:
                            return 33556318;
                        case 127999:
                            return 33556319;
                        default:
                            return 16779104;
                    }
                case 129306:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556321;
                        case 127996:
                            return 33556322;
                        case 127997:
                            return 33556323;
                        case 127998:
                            return 33556324;
                        case 127999:
                            return 33556325;
                        default:
                            return 16779110;
                    }
                case 129307:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556327;
                        case 127996:
                            return 33556328;
                        case 127997:
                            return 33556329;
                        case 127998:
                            return 33556330;
                        case 127999:
                            return 33556331;
                        default:
                            return 16779116;
                    }
                case 129308:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556333;
                        case 127996:
                            return 33556334;
                        case 127997:
                            return 33556335;
                        case 127998:
                            return 33556336;
                        case 127999:
                            return 33556337;
                        default:
                            return 16779122;
                    }
                case 129309:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556339;
                        case 127996:
                            return 33556340;
                        case 127997:
                            return 33556341;
                        case 127998:
                            return 33556342;
                        case 127999:
                            return 33556343;
                        default:
                            return 16779128;
                    }
                case 129310:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556345;
                        case 127996:
                            return 33556346;
                        case 127997:
                            return 33556347;
                        case 127998:
                            return 33556348;
                        case 127999:
                            return 33556349;
                        default:
                            return 16779134;
                    }
                case 129311:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556351;
                        case 127996:
                            return 33556352;
                        case 127997:
                            return 33556353;
                        case 127998:
                            return 33556354;
                        case 127999:
                            return 33556355;
                        default:
                            return 16779140;
                    }
                case 129312:
                    return 16779141;
                case 129313:
                    return 16779142;
                case 129314:
                    return 16779143;
                case 129315:
                    return 16779144;
                case 129316:
                    return 16779145;
                case 129317:
                    return 16779146;
                case 129318:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556364;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556364 : 67110796;
                                }
                                else
                                {
                                    return 67110795;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556366;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556366 : 67110798;
                                }
                                else
                                {
                                    return 67110797;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556368;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556368 : 67110800;
                                }
                                else
                                {
                                    return 67110799;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556370;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556370 : 67110802;
                                }
                                else
                                {
                                    return 67110801;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556372;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556372 : 67110804;
                                }
                                else
                                {
                                    return 67110803;
                                }
                            default:
                                return 16779158;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779158 : 50333590;
                    }
                    else
                    {
                        return 50333589;
                    }
                case 129319:
                    return 16779159;
                case 129320:
                    return 16779160;
                case 129321:
                    return 16779161;
                case 129322:
                    return 16779162;
                case 129323:
                    return 16779163;
                case 129324:
                    return 16779164;
                case 129325:
                    return 16779165;
                case 129326:
                    return 16779166;
                case 129327:
                    return 16779167;
                case 129328:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556384;
                        case 127996:
                            return 33556385;
                        case 127997:
                            return 33556386;
                        case 127998:
                            return 33556387;
                        case 127999:
                            return 33556388;
                        default:
                            return 16779173;
                    }
                case 129329:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556390;
                        case 127996:
                            return 33556391;
                        case 127997:
                            return 33556392;
                        case 127998:
                            return 33556393;
                        case 127999:
                            return 33556394;
                        default:
                            return 16779179;
                    }
                case 129330:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556396;
                        case 127996:
                            return 33556397;
                        case 127997:
                            return 33556398;
                        case 127998:
                            return 33556399;
                        case 127999:
                            return 33556400;
                        default:
                            return 16779185;
                    }
                case 129331:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556402;
                        case 127996:
                            return 33556403;
                        case 127997:
                            return 33556404;
                        case 127998:
                            return 33556405;
                        case 127999:
                            return 33556406;
                        default:
                            return 16779191;
                    }
                case 129332:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556408;
                        case 127996:
                            return 33556409;
                        case 127997:
                            return 33556410;
                        case 127998:
                            return 33556411;
                        case 127999:
                            return 33556412;
                        default:
                            return 16779197;
                    }
                case 129333:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556414;
                        case 127996:
                            return 33556415;
                        case 127997:
                            return 33556416;
                        case 127998:
                            return 33556417;
                        case 127999:
                            return 33556418;
                        default:
                            return 16779203;
                    }
                case 129334:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556420;
                        case 127996:
                            return 33556421;
                        case 127997:
                            return 33556422;
                        case 127998:
                            return 33556423;
                        case 127999:
                            return 33556424;
                        default:
                            return 16779209;
                    }
                case 129335:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556426;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556426 : 67110859;
                                }
                                else
                                {
                                    return 67110858;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556428;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556428 : 67110861;
                                }
                                else
                                {
                                    return 67110860;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556430;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556430 : 67110863;
                                }
                                else
                                {
                                    return 67110862;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556432;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556432 : 67110865;
                                }
                                else
                                {
                                    return 67110864;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556434;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556434 : 67110867;
                                }
                                else
                                {
                                    return 67110866;
                                }
                            default:
                                return 16779220;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779220 : 50333653;
                    }
                    else
                    {
                        return 50333652;
                    }
                case 129336:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556439;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556439 : 67110871;
                                }
                                else
                                {
                                    return 67110870;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556441;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556441 : 67110873;
                                }
                                else
                                {
                                    return 67110872;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556443;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556443 : 67110875;
                                }
                                else
                                {
                                    return 67110874;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556445;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556445 : 67110877;
                                }
                                else
                                {
                                    return 67110876;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556447;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556447 : 67110879;
                                }
                                else
                                {
                                    return 67110878;
                                }
                            default:
                                return 16779234;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779234 : 50333665;
                    }
                    else
                    {
                        return 50333664;
                    }
                case 129337:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556452;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556452 : 67110884;
                                }
                                else
                                {
                                    return 67110883;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556454;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556454 : 67110886;
                                }
                                else
                                {
                                    return 67110885;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556456;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556456 : 67110888;
                                }
                                else
                                {
                                    return 67110887;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556458;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556458 : 67110890;
                                }
                                else
                                {
                                    return 67110889;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556460;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556460 : 67110892;
                                }
                                else
                                {
                                    return 67110891;
                                }
                            default:
                                return 16779246;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779246 : 50333678;
                    }
                    else
                    {
                        return 50333677;
                    }
                case 129338:
                    return 16779247;
                case 129340:
                    if (c0914b.next() != 8205)
                    {
                        return 16779250;
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779250 : 50333681;
                    }
                    else
                    {
                        return 50333680;
                    }
                case 129341:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556468;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556468 : 67110900;
                                }
                                else
                                {
                                    return 67110899;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556470;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556470 : 67110902;
                                }
                                else
                                {
                                    return 67110901;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556472;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556472 : 67110904;
                                }
                                else
                                {
                                    return 67110903;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556474;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556474 : 67110906;
                                }
                                else
                                {
                                    return 67110905;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556476;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556476 : 67110908;
                                }
                                else
                                {
                                    return 67110907;
                                }
                            default:
                                return 16779263;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779263 : 50333694;
                    }
                    else
                    {
                        return 50333693;
                    }
                case 129342:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556480;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556480 : 67110913;
                                }
                                else
                                {
                                    return 67110912;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556482;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556482 : 67110915;
                                }
                                else
                                {
                                    return 67110914;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556484;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556484 : 67110917;
                                }
                                else
                                {
                                    return 67110916;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556486;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556486 : 67110919;
                                }
                                else
                                {
                                    return 67110918;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556488;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556488 : 67110921;
                                }
                                else
                                {
                                    return 67110920;
                                }
                            default:
                                return 16779276;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779276 : 50333707;
                    }
                    else
                    {
                        return 50333706;
                    }
                case 129344:
                    return 16779277;
                case 129345:
                    return 16779278;
                case 129346:
                    return 16779279;
                case 129347:
                    return 16779280;
                case 129348:
                    return 16779281;
                case 129349:
                    return 16779282;
                case 129351:
                    return 16779283;
                case 129352:
                    return 16779284;
                case 129353:
                    return 16779285;
                case 129354:
                    return 16779286;
                case 129355:
                    return 16779287;
                case 129356:
                    return 16779288;
                case 129357:
                    return 16779289;
                case 129358:
                    return 16779290;
                case 129359:
                    return 16779291;
                case 129360:
                    return 16779292;
                case 129361:
                    return 16779293;
                case 129362:
                    return 16779294;
                case 129363:
                    return 16779295;
                case 129364:
                    return 16779296;
                case 129365:
                    return 16779297;
                case 129366:
                    return 16779298;
                case 129367:
                    return 16779299;
                case 129368:
                    return 16779300;
                case 129369:
                    return 16779301;
                case 129370:
                    return 16779302;
                case 129371:
                    return 16779303;
                case 129372:
                    return 16779304;
                case 129373:
                    return 16779305;
                case 129374:
                    return 16779306;
                case 129375:
                    return 16779307;
                case 129376:
                    return 16779308;
                case 129377:
                    return 16779309;
                case 129378:
                    return 16779310;
                case 129379:
                    return 16779311;
                case 129380:
                    return 16779312;
                case 129381:
                    return 16779313;
                case 129382:
                    return 16779314;
                case 129383:
                    return 16779315;
                case 129384:
                    return 16779316;
                case 129385:
                    return 16779317;
                case 129386:
                    return 16779318;
                case 129387:
                    return 16779319;
                case 129388:
                    return 16779320;
                case 129389:
                    return 16779321;
                case 129390:
                    return 16779322;
                case 129391:
                    return 16779323;
                case 129392:
                    return 16779324;
                case 129395:
                    return 16779325;
                case 129396:
                    return 16779326;
                case 129397:
                    return 16779327;
                case 129398:
                    return 16779328;
                case 129402:
                    return 16779329;
                case 129404:
                    return 16779330;
                case 129405:
                    return 16779331;
                case 129406:
                    return 16779332;
                case 129407:
                    return 16779333;
                case 129408:
                    return 16779334;
                case 129409:
                    return 16779335;
                case 129410:
                    return 16779336;
                case 129411:
                    return 16779337;
                case 129412:
                    return 16779338;
                case 129413:
                    return 16779339;
                case 129414:
                    return 16779340;
                case 129415:
                    return 16779341;
                case 129416:
                    return 16779342;
                case 129417:
                    return 16779343;
                case 129418:
                    return 16779344;
                case 129419:
                    return 16779345;
                case 129420:
                    return 16779346;
                case 129421:
                    return 16779347;
                case 129422:
                    return 16779348;
                case 129423:
                    return 16779349;
                case 129424:
                    return 16779350;
                case 129425:
                    return 16779351;
                case 129426:
                    return 16779352;
                case 129427:
                    return 16779353;
                case 129428:
                    return 16779354;
                case 129429:
                    return 16779355;
                case 129430:
                    return 16779356;
                case 129431:
                    return 16779357;
                case 129432:
                    return 16779358;
                case 129433:
                    return 16779359;
                case 129434:
                    return 16779360;
                case 129435:
                    return 16779361;
                case 129436:
                    return 16779362;
                case 129437:
                    return 16779363;
                case 129438:
                    return 16779364;
                case 129439:
                    return 16779365;
                case 129440:
                    return 16779366;
                case 129441:
                    return 16779367;
                case 129442:
                    return 16779368;
                case 129460:
                    return 16779369;
                case 129461:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556586;
                        case 127996:
                            return 33556587;
                        case 127997:
                            return 33556588;
                        case 127998:
                            return 33556589;
                        case 127999:
                            return 33556590;
                        default:
                            return 16779375;
                    }
                case 129462:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556592;
                        case 127996:
                            return 33556593;
                        case 127997:
                            return 33556594;
                        case 127998:
                            return 33556595;
                        case 127999:
                            return 33556596;
                        default:
                            return 16779381;
                    }
                case 129463:
                    return 16779382;
                case 129464:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556599;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556599 : 67111032;
                                }
                                else
                                {
                                    return 67111031;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556601;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556601 : 67111034;
                                }
                                else
                                {
                                    return 67111033;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556603;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556603 : 67111036;
                                }
                                else
                                {
                                    return 67111035;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556605;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556605 : 67111038;
                                }
                                else
                                {
                                    return 67111037;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556607;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556607 : 67111040;
                                }
                                else
                                {
                                    return 67111039;
                                }
                            default:
                                return 16779393;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779393 : 50333826;
                    }
                    else
                    {
                        return 50333825;
                    }
                case 129465:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556611;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556611 : 67111044;
                                }
                                else
                                {
                                    return 67111043;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556613;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556613 : 67111046;
                                }
                                else
                                {
                                    return 67111045;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556615;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556615 : 67111048;
                                }
                                else
                                {
                                    return 67111047;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556617;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556617 : 67111050;
                                }
                                else
                                {
                                    return 67111049;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556619;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556619 : 67111052;
                                }
                                else
                                {
                                    return 67111051;
                                }
                            default:
                                return 16779405;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779405 : 50333838;
                    }
                    else
                    {
                        return 50333837;
                    }
                case 129472:
                    return 16779407;
                case 129473:
                    return 16779408;
                case 129474:
                    return 16779409;
                case 129488:
                    return 16779410;
                case 129489:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556627;
                        case 127996:
                            return 33556628;
                        case 127997:
                            return 33556629;
                        case 127998:
                            return 33556630;
                        case 127999:
                            return 33556631;
                        default:
                            return 16779416;
                    }
                case 129490:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556633;
                        case 127996:
                            return 33556634;
                        case 127997:
                            return 33556635;
                        case 127998:
                            return 33556636;
                        case 127999:
                            return 33556637;
                        default:
                            return 16779422;
                    }
                case 129491:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556639;
                        case 127996:
                            return 33556640;
                        case 127997:
                            return 33556641;
                        case 127998:
                            return 33556642;
                        case 127999:
                            return 33556643;
                        default:
                            return 16779428;
                    }
                case 129492:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556645;
                        case 127996:
                            return 33556646;
                        case 127997:
                            return 33556647;
                        case 127998:
                            return 33556648;
                        case 127999:
                            return 33556649;
                        default:
                            return 16779434;
                    }
                case 129493:
                    switch (c0914b.next())
                    {
                        case 127995:
                            return 33556651;
                        case 127996:
                            return 33556652;
                        case 127997:
                            return 33556653;
                        case 127998:
                            return 33556654;
                        case 127999:
                            return 33556655;
                        default:
                            return 16779440;
                    }
                case 129494:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556657;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556657 : 67111090;
                                }
                                else
                                {
                                    return 67111089;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556659;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556659 : 67111092;
                                }
                                else
                                {
                                    return 67111091;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556661;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556661 : 67111094;
                                }
                                else
                                {
                                    return 67111093;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556663;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556663 : 67111096;
                                }
                                else
                                {
                                    return 67111095;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556665;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556665 : 67111098;
                                }
                                else
                                {
                                    return 67111097;
                                }
                            default:
                                return 16779453;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779453 : 50333884;
                    }
                    else
                    {
                        return 50333883;
                    }
                case 129495:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556670;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556670 : 67111103;
                                }
                                else
                                {
                                    return 67111102;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556672;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556672 : 67111105;
                                }
                                else
                                {
                                    return 67111104;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556674;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556674 : 67111107;
                                }
                                else
                                {
                                    return 67111106;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556676;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556676 : 67111109;
                                }
                                else
                                {
                                    return 67111108;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556678;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556678 : 67111111;
                                }
                                else
                                {
                                    return 67111110;
                                }
                            default:
                                return 16779466;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779466 : 50333897;
                    }
                    else
                    {
                        return 50333896;
                    }
                case 129496:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556683;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556683 : 67111116;
                                }
                                else
                                {
                                    return 67111115;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556685;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556685 : 67111118;
                                }
                                else
                                {
                                    return 67111117;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556687;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556687 : 67111120;
                                }
                                else
                                {
                                    return 67111119;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556689;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556689 : 67111122;
                                }
                                else
                                {
                                    return 67111121;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556691;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556691 : 67111124;
                                }
                                else
                                {
                                    return 67111123;
                                }
                            default:
                                return 16779479;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779479 : 50333910;
                    }
                    else
                    {
                        return 50333909;
                    }
                case 129497:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556696;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556696 : 67111129;
                                }
                                else
                                {
                                    return 67111128;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556698;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556698 : 67111131;
                                }
                                else
                                {
                                    return 67111130;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556700;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556700 : 67111133;
                                }
                                else
                                {
                                    return 67111132;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556702;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556702 : 67111135;
                                }
                                else
                                {
                                    return 67111134;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556704;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556704 : 67111137;
                                }
                                else
                                {
                                    return 67111136;
                                }
                            default:
                                return 16779490;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779490 : 50333923;
                    }
                    else
                    {
                        return 50333922;
                    }
                case 129498:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556708;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556708 : 67111141;
                                }
                                else
                                {
                                    return 67111140;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556710;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556710 : 67111143;
                                }
                                else
                                {
                                    return 67111142;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556712;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556712 : 67111145;
                                }
                                else
                                {
                                    return 67111144;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556714;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556714 : 67111147;
                                }
                                else
                                {
                                    return 67111146;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556716;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556716 : 67111149;
                                }
                                else
                                {
                                    return 67111148;
                                }
                            default:
                                return 16779502;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779502 : 50333935;
                    }
                    else
                    {
                        return 50333934;
                    }
                case 129499:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556720;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556720 : 67111153;
                                }
                                else
                                {
                                    return 67111152;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556722;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556722 : 67111155;
                                }
                                else
                                {
                                    return 67111154;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556724;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556724 : 67111157;
                                }
                                else
                                {
                                    return 67111156;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556726;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556726 : 67111159;
                                }
                                else
                                {
                                    return 67111158;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556728;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556728 : 67111161;
                                }
                                else
                                {
                                    return 67111160;
                                }
                            default:
                                return 16779514;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779514 : 50333947;
                    }
                    else
                    {
                        return 50333946;
                    }
                case 129500:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556732;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556732 : 67111165;
                                }
                                else
                                {
                                    return 67111164;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556734;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556734 : 67111167;
                                }
                                else
                                {
                                    return 67111166;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556736;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556736 : 67111169;
                                }
                                else
                                {
                                    return 67111168;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556738;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556738 : 67111171;
                                }
                                else
                                {
                                    return 67111170;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556740;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556740 : 67111173;
                                }
                                else
                                {
                                    return 67111172;
                                }
                            default:
                                return 16779526;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779526 : 50333959;
                    }
                    else
                    {
                        return 50333958;
                    }
                case 129501:
                    next2 = c0914b.next();
                    if (next2 != 8205)
                    {
                        switch (next2)
                        {
                            case 127995:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556744;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556744 : 67111177;
                                }
                                else
                                {
                                    return 67111176;
                                }
                            case 127996:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556746;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556746 : 67111179;
                                }
                                else
                                {
                                    return 67111178;
                                }
                            case 127997:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556748;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556748 : 67111181;
                                }
                                else
                                {
                                    return 67111180;
                                }
                            case 127998:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556750;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556750 : 67111183;
                                }
                                else
                                {
                                    return 67111182;
                                }
                            case 127999:
                                if (c0914b.next() != 8205)
                                {
                                    return 33556752;
                                }
                                next2 = c0914b.next();
                                if (next2 != 9792)
                                {
                                    return next2 != 9794 ? 33556752 : 67111185;
                                }
                                else
                                {
                                    return 67111184;
                                }
                            default:
                                return 16779538;
                        }
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779538 : 50333971;
                    }
                    else
                    {
                        return 50333970;
                    }
                case 129502:
                    if (c0914b.next() != 8205)
                    {
                        return 16779540;
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779540 : 50333973;
                    }
                    else
                    {
                        return 50333972;
                    }
                case 129503:
                    if (c0914b.next() != 8205)
                    {
                        return 16779542;
                    }
                    next2 = c0914b.next();
                    if (next2 != 9792)
                    {
                        return next2 != 9794 ? 16779542 : 50333975;
                    }
                    else
                    {
                        return 50333974;
                    }
                case 129504:
                    return 16779544;
                case 129505:
                    return 16779545;
                case 129506:
                    return 16779546;
                case 129507:
                    return 16779547;
                case 129508:
                    return 16779548;
                case 129509:
                    return 16779549;
                case 129510:
                    return 16779550;
                case 129511:
                    return 16779551;
                case 129512:
                    return 16779552;
                case 129513:
                    return 16779553;
                case 129514:
                    return 16779554;
                case 129515:
                    return 16779555;
                case 129516:
                    return 16779556;
                case 129517:
                    return 16779557;
                case 129518:
                    return 16779558;
                case 129519:
                    return 16779559;
                case 129520:
                    return 16779560;
                case 129521:
                    return 16779561;
                case 129522:
                    return 16779562;
                case 129523:
                    return 16779563;
                case 129524:
                    return 16779564;
                case 129525:
                    return 16779565;
                case 129526:
                    return 16779566;
                case 129527:
                    return 16779567;
                case 129528:
                    return 16779568;
                case 129529:
                    return 16779569;
                case 129530:
                    return 16779570;
                case 129531:
                    return 16779571;
                case 129532:
                    return 16779572;
                case 129533:
                    return 16779573;
                case 129534:
                    return 16779574;
                case 129535:
                    return 16779575;
                default:
                    switch (next)
                    {
                        case 48 /*48*/:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554434;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331650;
                            }
                            return i2;
                        case 49:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554435;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331651;
                            }
                            return i2;
                        case 50 /*50*/:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554436;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331652;
                            }
                            return i2;
                        case 51:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554437;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331653;
                            }
                            return i2;
                        case 52:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554438;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331654;
                            }
                            return i2;
                        case 53:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554439;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331655;
                            }
                            return i2;
                        case 54:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554440;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331656;
                            }
                            return i2;
                        case 55:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554441;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331657;
                            }
                            return i2;
                        case 56:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554442;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331658;
                            }
                            return i2;
                        case 57:
                            next2 = c0914b.next();
                            if (next2 == 8419)
                            {
                                return 33554443;
                            }
                            if (next2 != 65039)
                            {
                                return -1;
                            }
                            if (c0914b.next() == 8419)
                            {
                                i2 = 50331659;
                            }
                            return i2;
                        default:
                            switch (next)
                            {
                                case 8596:
                                    return 16779580;
                                case 8597:
                                    return 16779581;
                                case 8598:
                                    return 16779582;
                                case 8599:
                                    return 16779583;
                                case 8600:
                                    return 16779584;
                                case 8601:
                                    return 16779585;
                                default:
                                    switch (next)
                                    {
                                        case 9208:
                                            return 16779603;
                                        case 9209:
                                            return 16779604;
                                        case 9210:
                                            return 16779605;
                                        default:
                                            switch (next)
                                            {
                                                case 9723:
                                                    return 16779611;
                                                case 9724:
                                                    return 16779612;
                                                case 9725:
                                                    return 16779613;
                                                case 9726:
                                                    return 16779614;
                                                default:
                                                    switch (next)
                                                    {
                                                        case 9728:
                                                            return 16779615;
                                                        case 9729:
                                                            return 16779616;
                                                        case 9730:
                                                            return 16779617;
                                                        case 9731:
                                                            return 16779618;
                                                        case 9732:
                                                            return 16779619;
                                                        default:
                                                            return -1;
                                                    }
                                            }
                                    }
                            }
                    }
            }
        }
    }
}
