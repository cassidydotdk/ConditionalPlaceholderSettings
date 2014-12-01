# Conditional Placeholder Settings #

This is a module for Sitecore that is intended to allow for the use of the Sitecore Rules Engine to support the existing placeholder settings functionality present within Sitecore.

It will allow rules to be set up to add and/or remove renderings and forbid placeholders from being edited.  These rules can use conditions to act based on the placeholder key, context item, user, and various other conditions that are available out-of-the-box.

It's something I found in my notebook and thought it would be fun to hack together and write a [blog post](http://www.matthewkenny.com/2014/12/conditional-placeholder-settings) about.

It is built against Sitecore 7.1 (as the lowest supported version) due to the restructuring of the Rules folder in that version.  It will probably work in versions of 7.0, but you will need to modify items in order for anything to work.

If I decide to develop this further, then I'll do some refactoring, write some unit tests and try it in some more versions of Sitecore. I'll also try and resolve any issues that arise.  Currently, though, it's provided as-is.

It's licensed under MIT - so do what you like with it pretty much.  There's no obligation, but if you do something cool with it, I'd love to hear from you.

###Known issues###
* The "number of renderings in placeholder" condition doesn't take into account any renderings that have been added but not yet saved.  As such, it can lead to false positives/negatives.
