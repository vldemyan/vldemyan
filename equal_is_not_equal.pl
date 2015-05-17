#!/usr/bin/perl
use warnings;
use strict;
use Data::Dumper;

my $a = [
#    1.9999999999999999,
    1.999999999999999,
#    1.99999999999999,
];
my $b = 2;

foreach my $i ( 0..$#$a ) {
    print "$a->[$i] and $b are equal\n" if ($a->[$i] == $b);
    print "$a->[$i] is greater than $b\n" if ($a->[$i] > $b);
    print "$a->[$i] is lower than $b\n" if ($a->[$i] < $b);
}