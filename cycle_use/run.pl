#!/usr/bin/perl
use strict;
use warnings;
use Data::Dumper;

use Pac1;  #comment this line and issue disappears
use Pac2;

my $res = Pac2::some_sub();

print Dumper $res;
