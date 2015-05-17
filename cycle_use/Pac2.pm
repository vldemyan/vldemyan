package Pac2;

use strict;
use warnings;
use Data::Dumper;

use Pac1;

my @SOME_ARRAY = ( $Pac1::SOME_CONSTANT );

sub some_sub {
    return \@SOME_ARRAY;
}
