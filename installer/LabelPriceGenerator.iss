<Window x:Class="LabelPriceGenerator.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Generator de etichete de pret" Height="760" Width="1180" WindowStartupLocation="CenterScreen">
    <Grid Margin="12">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="2*" />
            <ColumnDefinition Width="3*" />
        </Grid.ColumnDefinitions>

        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <TextBlock Grid.Column="0" Grid.ColumnSpan="2" Grid.Row="0" Text="Generator de etichete de pret" FontSize="26" FontWeight="Bold" Margin="0,0,0,12"/>

        <GroupBox Grid.Row="1" Grid.Column="0" Header="Produse" Margin="0,0,10,0">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>

                <DataGrid x:Name="ProductGrid" AutoGenerateColumns="False" IsReadOnly="True" SelectionMode="Single" Margin="8">
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="Nume" Binding="{Binding Name}" Width="*"/>
                        <DataGridTextColumn Header="Pret" Binding="{Binding Price, StringFormat={}{0:0.00}}" Width="90"/>
                        <DataGridTextColumn Header="Promo" Binding="{Binding PromoPrice, StringFormat={}{0:0.00}}" Width="90"/>
                        <DataGridTextColumn Header="Unit" Binding="{Binding Unit}" Width="70"/>
                    </DataGrid.Columns>
                </DataGrid>

                <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Right" Margin="8">
                    <Button x:Name="AddButton" Content="Adauga" Width="110"/>
                    <Button x:Name="DeleteButton" Content="Sterge" Width="110"/>
                </StackPanel>
            </Grid>
        </GroupBox>

        <Grid Grid.Row="1" Grid.Column="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>

            <GroupBox Header="Detalii produs" Margin="0,0,0,8">
                <Grid Margin="8">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="180"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                    </Grid.RowDefinitions>

                    <TextBlock Text="Nume produs" Grid.Row="0" Grid.Column="0" VerticalAlignment="Center" Margin="0,0,10,0"/>
                    <TextBox x:Name="NameTextBox" Grid.Row="0" Grid.Column="1"/>

                    <TextBlock Text="Pret" Grid.Row="1" Grid.Column="0" VerticalAlignment="Center" Margin="0,0,10,0"/>
                    <TextBox x:Name="PriceTextBox" Grid.Row="1" Grid.Column="1"/>

                    <TextBlock Text="Pret promo" Grid.Row="2" Grid.Column="0" VerticalAlignment="Center" Margin="0,0,10,0"/>
                    <TextBox x:Name="PromoPriceTextBox" Grid.Row="2" Grid.Column="1"/>

                    <TextBlock Text="Unitate" Grid.Row="3" Grid.Column="0" VerticalAlignment="Center" Margin="0,0,10,0"/>
                    <TextBox x:Name="UnitTextBox" Grid.Row="3" Grid.Column="1" Text="buc"/>

                    <TextBlock Text="Cod bare" Grid.Row="4" Grid.Column="0" VerticalAlignment="Center" Margin="0,0,10,0"/>
                    <TextBox x:Name="BarcodeTextBox" Grid.Row="4" Grid.Column="1"/>

                    <TextBlock Text="Observatii" Grid.Row="5" Grid.Column="0" VerticalAlignment="Top" Margin="0,0,10,0"/>
                    <TextBox x:Name="NotesTextBox" Grid.Row="5" Grid.Column="1" Height="70" AcceptsReturn="True" TextWrapping="Wrap"/>
                </Grid>
            </GroupBox>

            <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Right" Margin="0,0,0,8">
                <Button x:Name="SaveButton" Content="Salveaza" Width="110"/>
                <Button x:Name="RefreshPreviewButton" Content="Actualizeaza previzualizare" Width="180"/>
                <Button x:Name="ExportPdfButton" Content="Export PDF" Width="120"/>
                <Button x:Name="ClearFormButton" Content="Clear" Width="100"/>
            </StackPanel>

            <GroupBox Grid.Row="2" Header="Previzualizare eticheta" Margin="0,8,0,0">
                <Border Background="#FAFAFA" BorderBrush="#D0D0D0" BorderThickness="1" Margin="10" Padding="10">
                    <Image x:Name="PreviewImage" Stretch="Uniform" Width="430" Height="260"/>
                </Border>
            </GroupBox>
        </Grid>
    </Grid>
</Window>
