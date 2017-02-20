# PortfolioApp
This app was created in visual studio 2015
The UI is done in WPF and MVVM and has a dependency on MVVMLight. These dependencies are added as packages and nuget package manager in VS will automatically get them 
There Unit tests are written using MS Unit Tests 

Design/Input 

The button Add will only activate if a number is entered in the price and quantity textboxes. I've allowed for -ve values to be entered so that one can have -ve market valuet to trigger the cell in the datagrid to be highlighted. 

The UI has two datagrid one for the fund and another for the summary. The summary has been done as a grid so that it is generic enough so that other asset types can be easily added without having to modifiy the UI. The total row in the the summary grid is higlighted. 

A new asset class can be added easily without having to change the UI via the Stockfactory and AssetType enum. 

