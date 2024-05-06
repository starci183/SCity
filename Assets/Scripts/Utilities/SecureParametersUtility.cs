using System.IO;
using UnityEngine;

public static class SecureParametersUtility
{
#if UNITY_STANDALONE_LINUX
    public static readonly string ServerCommonName = "direct.tromcho.net";
    public static readonly string ClientCA =
      @"-----BEGIN CERTIFICATE-----
MIIDGzCCAgOgAwIBAgIUTMKUsChcq7J7s83ON94y8tKulwgwDQYJKoZIhvcNAQEL
BQAwHTEbMBkGA1UEAwwSZGlyZWN0LnRyb21jaG8ubmV0MB4XDTI0MDUwNTAwMjI1
MVoXDTI3MDUwNTAwMjI1MVowHTEbMBkGA1UEAwwSZGlyZWN0LnRyb21jaG8ubmV0
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1V8WreO9N8aPgOMqVD18
SDlXf2TEY3zSnc90+GTRZHjQJN1IDXmgc6QOu3iMUtjrf3J7/ATD3kRzpZGlW+ON
yPG9vDIOtMIRbXK4hv2OU8OpeWUjnZ5d0NWYDGxjxRmuGnP46RkAKzWchOnWRSkz
n4owMP8m9GisGb++xKY3cA/GLPTeNJzXObuSpNWk6CzUGx++kk1k3mhmTtmqIqE2
i2fY37jTUiOwPzvnA/MIQS/5OZjqITZ06zxfcmD5aujqfRrcVewjXyQOnLZ/Hp85
jyz0XAiSdd3EXIUxc+bJ9MO/gfoTIV4ADCVZq/S8qqvSocb3p15L7KoHVDETImQc
uQIDAQABo1MwUTAdBgNVHQ4EFgQULeZwHkPfkYLL9LDpiMBuLZrdGDAwHwYDVR0j
BBgwFoAULeZwHkPfkYLL9LDpiMBuLZrdGDAwDwYDVR0TAQH/BAUwAwEB/zANBgkq
hkiG9w0BAQsFAAOCAQEAckKXqAdQisZHZv0wd59bDqOAR3vvouTrGIps6uFbGPE5
gSBkdNwRD0BWz9we8G7mfai8D/GJWDQIgDEDfgF9QrdXBIpcDuNdFUPZmSkdS0SZ
SPXpBWHW9O7dXe+RYb/nOVMmVaVuTOuqkv6Z+qwrXk2E0gvBtwepayqu/URMkwOL
cVF1Sw4fVWzdq4EJWgk5PCJ/eG32Vyd9m1gyALnqiNH0Y2P8MPnuAwBZRgz5dNPz
9+ddA69whCfUS0xyEdMP9MkqzBsGdGIhXMBDS3h6gOfK3BL4fovAUoEcwlG0dvtp
MbBzUsm0us5H6LC3xkz2DaWuHe17CYDd+4mRCb0P2A==
-----END CERTIFICATE-----";
    public static readonly string ServerCertificate =
        @"-----BEGIN CERTIFICATE-----
MIIDCjCCAfKgAwIBAgIUJKQ/ZT3NwHutjVP8l5GhxMDwgR8wDQYJKoZIhvcNAQEL
BQAwHTEbMBkGA1UEAwwSZGlyZWN0LnRyb21jaG8ubmV0MB4XDTI0MDUwNTAwMjU0
MFoXDTI1MDUwNTAwMjU0MFowHTEbMBkGA1UEAwwSZGlyZWN0LnRyb21jaG8ubmV0
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwtxE9RsEgx0+w3WHX5Lj
dOl842xblORy3o2/hpNEZP5CFcUyB0M94FKRVfJ00mChV1MdYEJM3x1Lz1EPxbZQ
NLdtD+gN610lJ7DZH8ejqUMya2WJCid/R8ee99dhWBupyrTqMC41Jt5l1YnFRTOu
iQIfpqBTr12i4+0KH0lKL5laNLsJ0PFYshAs5+KCwUfhM1KbbKMpT8rI0XPAp/na
1SVu4lnc4PzXn2ddzxo51l3RozySwLhuiS3BGo9JeMZ1Sx1cyuiNbUF/fx49KiMH
qTn0CBKFoK+Eq1PCPynesidM/BUyhePuN73I+faj2tp2+kTIoJCy8APfqqANXFpR
+wIDAQABo0IwQDAdBgNVHQ4EFgQUT1AgB6frLuvN4p2N8gyiUXkX9PIwHwYDVR0j
BBgwFoAULeZwHkPfkYLL9LDpiMBuLZrdGDAwDQYJKoZIhvcNAQELBQADggEBAM18
pWmh6vj6fGzPdoB37O7IKVDN80XOw6DTDgKq58LssWnfa7kJpfOfbXmJmcRWUaCE
2FVMXx51y+r2RLzgwRFVlx+8/5ROIhFZnP1u0TzVonsjkZau/mQ6N6mdCnfKuCxY
KB6wamwpqHJIEapblYeoB7JmL7yKmZfDgyH1WnRHsVLAX9lKVl/YnJ4cSf2npuVc
Z3TCRTRDhXY+H7s/Z0mYd6uuGq+Wy97nZnalT/rjYar1mzPQjeZdSnzKb1IdD0Wv
MkosCTVMZkoaDYmHyxifMimFxKiWxPStUY1fBgLg8o9BfkbjBq481iUQ5djFlgqd
nJqC0znWH7t27hWp4vI=
-----END CERTIFICATE-----";
    public static readonly string ServerPrivateKey =
    @"-----BEGIN PRIVATE KEY-----
MIIEugIBADANBgkqhkiG9w0BAQEFAASCBKQwggSgAgEAAoIBAQDC3ET1GwSDHT7D
dYdfkuN06XzjbFuU5HLejb+Gk0Rk/kIVxTIHQz3gUpFV8nTSYKFXUx1gQkzfHUvP
UQ/FtlA0t20P6A3rXSUnsNkfx6OpQzJrZYkKJ39Hx57312FYG6nKtOowLjUm3mXV
icVFM66JAh+moFOvXaLj7QofSUovmVo0uwnQ8ViyECzn4oLBR+EzUptsoylPysjR
c8Cn+drVJW7iWdzg/NefZ13PGjnWXdGjPJLAuG6JLcEaj0l4xnVLHVzK6I1tQX9/
Hj0qIwepOfQIEoWgr4SrU8I/Kd6yJ0z8FTKF4+43vcj59qPa2nb6RMigkLLwA9+q
oA1cWlH7AgMBAAECgf8XKk36SOvLp7sNtwMTlhsXfaeuMekFr6coHNOeO4be9or4
YswPxQPEjI26moSi3adZDUkr0pQ0zYB3zzfiYTZ2jIIMdFXcFFcOs+JoCsLqHSJv
ZwD4xPGN8mygohqdfGjnFve35F5OUBm3bxibJbVX/0bgHr7AcCTPu6NEYNufVqXa
bpKBFvm2bWvVvkW/X9Awr/1RouFHo2hwnFvWcykWAHytTxxxm1rVlsgay+6Q2TGs
lyDZwjPDRGdMH8hcGeahDbCwTz95Z5OYIhreQlrQnfYTWweSS8362NIA9RVWApW4
8StF3V5OmjrFrAWUEaOksuIaAtw0Hd3sJ4qKUE0CgYEA7/HXzMXuIduROUesbvyr
v0UWEKFD4JXXq/pihs/atPkopNsw/3ftU6pSxGpCqD/vgRjqlhCQpNB6KDGSvLx2
YPmYmJsE/gOOyFc36kkqCFqeO9u0FbdWMNEylEmIRu/S+kcuOi/D+Jum6QOn2oTm
OtlIUnnxkpfUBG1Fg6tj728CgYEAz+Ymmm5nfhqyypiWmdSdbHIupOZ198P2qb9K
1+FPvOvcVNcZRPvdB54zmy9bWfF6pCSbMYDPHTIkT296g2VuGbrc5ff3sHmD+mmF
TP9HWx6AfDnhUbKpH/w2FjYsKRiSRhMNaWznT0KUau43SOq0nHayPlXR9r6digeD
7mESQDUCgYAH+z92bE8TiT43bY7q0jTUU/P78aFUYyedbOLCIT/hLTiQ40mp9c9L
LSs7pV06Q4YwASgsfbiSAu1NUPjUlmBJsYPF78ImwO+K8nvFq1FencUNsK0427Re
Q1cvX5LM6UVXVe7PuK8IIgVXUuvOdQVDh97D/5JtkedXjlr1mknkuQKBgAUbeFNO
5wf4C/BiM0DwMjXZ0D+I0dkWXVbqNiJ7jIPtn2oOJrbFITbwsf/b9/iLsCGcLJvY
uD3VX4L8EBxuP3guWQLlRpZ1RcK/GOE9XDlm1G041so1A2afwYxmJEuWKPHDwg6W
+E/AKPk/hOgrq+g0Gkjhvti68g/UA2+1vscJAoGAU2uu0Ael3oKAxd990JTY/hlN
gO9PGoWwuG548O9gRUZ+tPPIEl5LEjjcCWz8x4OszfiZh5jgdichFtlH6BUaaLps
kfHNyFBf4Qi/5NpeefeUm+8edQe9ksQjJzao99BWflaQD7KuVC23C2SzvviaGthI
uWOKpWbSOV6Ii5rLsuk=
-----END PRIVATE KEY-----";
#else
 public static readonly string ServerCommonName = "localhost";
    public static readonly string ClientCA =
      @"-----BEGIN CERTIFICATE-----
MIIDCTCCAfGgAwIBAgIUKSFVWVZ8rSTeCMJRxbSjAMVB7qEwDQYJKoZIhvcNAQEL
BQAwFDESMBAGA1UEAwwJbG9jYWxob3N0MB4XDTI0MDUwNTAxMjYwN1oXDTI3MDUw
NTAxMjYwN1owFDESMBAGA1UEAwwJbG9jYWxob3N0MIIBIjANBgkqhkiG9w0BAQEF
AAOCAQ8AMIIBCgKCAQEAh0haaSuyjhjyz9vsQwZEVNbWPXZf4+PC702k4X2G0YeM
GNONvcJOEDOUqyNOsRZKyFJs4//FPiGbmr/XtAT5XWkTBLU6b2eHDulwPxaOwSty
r0Y6v3iGOY9k/SSfWjM/lPO9JmY7tasqJ8ylF3LMSMihOT1d8Ehea5VRjqdZbkCP
M1lYFx7dEmMF9C7SqNW8VbDKm27D5AhMDX+Up2o+eA+q52yse8EPGtEApmqp2yR8
SBd5VEhA2iLfotXw6oeVjwQdVVRHdYpYal0Enzd9Iq5/UBlNlzeu+pU7oSPnXZ3J
JnTRw3z5ktRG3+ErzK6bPtKVmD4Zv94eKHjJGeyXowIDAQABo1MwUTAdBgNVHQ4E
FgQUtX0nVmIihpwIBUBF0TJEt3KvUxQwHwYDVR0jBBgwFoAUtX0nVmIihpwIBUBF
0TJEt3KvUxQwDwYDVR0TAQH/BAUwAwEB/zANBgkqhkiG9w0BAQsFAAOCAQEAU6QB
QmNAK5sFmI6ob9LOD3Ui68yryUki0O+mv+w/ZnZ/2WPos2NyQbtIBUeU/odDbrBv
RnvXdvzPT4VwL/uj37g0q2cxsqz4J176Pt884YbjS8L98e01CXdMaQSKD7CoHkAt
Gibo5UwD5Z5t/gzdZFlgNtp13MBqrkNBdoj8kEio27x6wvffdODp+ORhTlcMp7Xv
1q0AaY00fRz2QBvuWPrXRsZTdI1C5mvRMR+EaKr8Eugjz5ZeZzbzRKl7Rpj6eeiV
8i3XiIEVpUhaau5JK/zS6vFhjqMf8GhEkCLQshAjb7bNTReRG28TI0UAwhfPILif
9i5mNTG7DzmA/R8O+g==
-----END CERTIFICATE-----";
    public static readonly string ServerCertificate =
        @"-----BEGIN CERTIFICATE-----
MIIC+DCCAeCgAwIBAgIUFfvS1Pg5MJVcaagQa/wS2Y+ZEbYwDQYJKoZIhvcNAQEL
BQAwFDESMBAGA1UEAwwJbG9jYWxob3N0MB4XDTI0MDUwNTAxMjY0NloXDTI1MDUw
NTAxMjY0NlowFDESMBAGA1UEAwwJbG9jYWxob3N0MIIBIjANBgkqhkiG9w0BAQEF
AAOCAQ8AMIIBCgKCAQEAtHCQlrGMDStko80ywDZT9uv34Ddc21Vax7bBixjVpTPE
BtSZaejeRHUK4rWgvtqeSLge8jifrWIvLDcurR2Yv7TUM9BlmN0v3BGbFqa8nUh0
M1lIU/qjIFGRPa/ruSRhayIEO+O4/eeh/Xv9Pwa2HktS72TPB53ZbPdPz+DVqHm/
wyJPRtVVK5uS8cV+kn/Mfc/lWBnDseDeex64jNMer5rB07rxGh21q1fSbvvG+r3o
7aATeZOucTtVKm2Rcs1hC0e3H8+Cn34oWojcP5lcAwwTb8qCRkb2r41GFwCnGx8q
1ZDcOZhIpYoTwkTADN4W8X+pvrkM6KkAF2kZ/PjyYQIDAQABo0IwQDAdBgNVHQ4E
FgQUx/ChTpSqBJzBiOpz5flD/20P6D8wHwYDVR0jBBgwFoAUtX0nVmIihpwIBUBF
0TJEt3KvUxQwDQYJKoZIhvcNAQELBQADggEBAG8EPDSXYZfpYoXIy05gwE8ocKMN
al0taqr6Bbjn0tEaJghmhiI16yy5N4nPxz7IPjjXraiIwh/ao2aBlVaRVHPsq2HX
Bt65JcgRHO5DMAB9K9EHdCn6LrSAGKtr/z9fRKdcb5DdyXRpZgnwBEzsvlT3FHDT
HTYCZ+J0tJg0PqBZFnYaRKVF2+iw4hSan2soquKVbT0rY7FwtA4YnwCQ7vhmkTnT
ZtuQaBLNo40RbPnkYs+bI6crxyFIJYBSZ/ZJPECbptesWwoc9ahR8Z58fBCHyhsY
C2sQQgbEgpFSNTAYy+Z4qveXj7nm/cDERd1+D6Wan74nVRtVesqOcmuRbzg=
-----END CERTIFICATE-----";
    public static readonly string ServerPrivateKey =
    @"-----BEGIN PRIVATE KEY-----
MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC0cJCWsYwNK2Sj
zTLANlP26/fgN1zbVVrHtsGLGNWlM8QG1Jlp6N5EdQritaC+2p5IuB7yOJ+tYi8s
Ny6tHZi/tNQz0GWY3S/cEZsWprydSHQzWUhT+qMgUZE9r+u5JGFrIgQ747j956H9
e/0/BrYeS1LvZM8Hndls90/P4NWoeb/DIk9G1VUrm5LxxX6Sf8x9z+VYGcOx4N57
HriM0x6vmsHTuvEaHbWrV9Ju+8b6vejtoBN5k65xO1UqbZFyzWELR7cfz4Kffiha
iNw/mVwDDBNvyoJGRvavjUYXAKcbHyrVkNw5mEilihPCRMAM3hbxf6m+uQzoqQAX
aRn8+PJhAgMBAAECggEAB1Il26daelJPZAH4VCogH/2U8gjtAI0nAMFeeulICcre
4jQQAWcMVZS2G1qpKfUuxN6LiuJXQC6ioVWf1DBGOUj57xw+cwROY8xnEXU0Y+FD
ra2qrJWXtsD4dptDoiBiv3kC2Pc1Uz/pp6I3NS5thy8hL0tUxwdVggFKwLFrmck9
Jn5hGgtsDD8HSe8QiYYMOFsW+yAjgybn7EoqcZ7mPL/QcgMjvtVvu3X/0puRwwvo
uNeWtvWFf6+klzWow73N54VUbS5mdZaPQwtYmrDMrtWyjFXSivNwJu7qDoRGUX16
JX/BleHfITnw1OKAY38rHUHq7ZcCSpx6UU3M3D+IQQKBgQD5tUXeD9YuSzAZUgXG
ATc/Yz+CX/OWraO0objHXxHn2H281OqDEzWpzEshD6nDPDc+YJSjcBI541cw/2Zv
P5NBAPvE5Okh9FMY+PP9+aYcXESsV853hYGAyY8s/pvIsvHjFLjf3fPFWvk/QrRo
LmFASY49OokT2h0CGVMpZDz/eQKBgQC4/Hrz6vvems3qLNtOmz1oYioDDpHxx0Fk
doNtr2gTWRUCgkWfOhuxSOI1HekiNGaIND9fngm9OSdpgGa9KsvTeAeYQiMpshkq
ww0m3Mbs434yCsJJpMGyIcYphGJ6TT0zcPF9sUjz1FS/bjOy2dAPIScIPkvnki3v
w7sJ6apIKQKBgDPLsBRhwJGVswJtixkJQ4Z4dcH7WTGWDvD24rcoNzSaKWqz13kc
0PLJl4PiFdqTcPoVWn+UTZOIXpuhPoQw8cB4DcFHojwSy/HQIfw6foQ/d1cwV3lf
Tf+Cz5oLrhCxXY82yypUha4YMr82fOlnRXDqUQDOVYSyp3W5/xAE5MoxAoGAORWw
25SoJQmggaNWCeveB1hDnq3gW7whcd8gr7hxZYcX9K4+zeQgp5TWOY4BY4zIF0AI
Tnl2h+4bO3NkQPvz6k4gCdxe/X74RTnr1RJMUM3jI44uZotxOocxn546xYMQX896
tk7/ND9R58EaMxcEHacdZG3U/qEdi9/a2DRDWAECgYEAtjVXCjaFdwyqUZY9skue
SIDF+fquRsc1HMrnz4fGSbg4t8ZS4SPhQukXzm1fJuEA9HqHUrtd21xQI6cu8cWj
/+6P8IX1u5Pd5qKmPckUoOqh5rKHcgoPo0yOd40ZmgRV4kpBZ+c+2dw6u8+/5uUp
ft2h6wucq34jEpgXoukjoHY=
-----END PRIVATE KEY-----";
#endif
}