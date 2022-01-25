<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticaSuelos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.ButtonExportar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FosforoBray = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FosforoCitrico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nitratos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pHAgua = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pHKCI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PotasioIntercambiable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sulfatos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NitrogenoVegetal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CarbonoOrganico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MateriaOrganica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Calcio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Magnesio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sodio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AcidezTitulable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtDesde = New System.Windows.Forms.DateTimePicker()
        Me.DtHasta = New System.Windows.Forms.DateTimePicker()
        Me.BtnListar2020 = New System.Windows.Forms.Button()
        Me.BtnExcelExportar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(312, 32)
        Me.ButtonListar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonListar.TabIndex = 20
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Desde"
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(157, 36)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(132, 22)
        Me.DateHasta.TabIndex = 13
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(16, 36)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(132, 22)
        Me.DateDesde.TabIndex = 12
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.ButtonExportar.Location = New System.Drawing.Point(420, 32)
        Me.ButtonExportar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonExportar.TabIndex = 22
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Ficha, Me.FosforoBray, Me.FosforoCitrico, Me.Nitratos, Me.pHAgua, Me.pHKCI, Me.PotasioIntercambiable, Me.Sulfatos, Me.NitrogenoVegetal, Me.CarbonoOrganico, Me.MateriaOrganica, Me.PMN, Me.Calcio, Me.Magnesio, Me.Sodio, Me.AcidezTitulable, Me.CIC, Me.SB})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 125)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1361, 613)
        Me.DataGridView1.TabIndex = 23
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 80
        '
        'FosforoBray
        '
        Me.FosforoBray.HeaderText = "Fósforo Bray"
        Me.FosforoBray.Name = "FosforoBray"
        Me.FosforoBray.Width = 55
        '
        'FosforoCitrico
        '
        Me.FosforoCitrico.HeaderText = "Fósforo cítrico"
        Me.FosforoCitrico.Name = "FosforoCitrico"
        Me.FosforoCitrico.Width = 55
        '
        'Nitratos
        '
        Me.Nitratos.HeaderText = "Nitratos"
        Me.Nitratos.Name = "Nitratos"
        Me.Nitratos.Width = 55
        '
        'pHAgua
        '
        Me.pHAgua.HeaderText = "pH Agua"
        Me.pHAgua.Name = "pHAgua"
        Me.pHAgua.Width = 55
        '
        'pHKCI
        '
        Me.pHKCI.HeaderText = "pH KCI"
        Me.pHKCI.Name = "pHKCI"
        Me.pHKCI.Width = 55
        '
        'PotasioIntercambiable
        '
        Me.PotasioIntercambiable.HeaderText = "Potasio Intercambiable"
        Me.PotasioIntercambiable.Name = "PotasioIntercambiable"
        Me.PotasioIntercambiable.Width = 55
        '
        'Sulfatos
        '
        Me.Sulfatos.HeaderText = "Sulfatos"
        Me.Sulfatos.Name = "Sulfatos"
        Me.Sulfatos.Width = 55
        '
        'NitrogenoVegetal
        '
        Me.NitrogenoVegetal.HeaderText = "Nitrogeno vegetal %"
        Me.NitrogenoVegetal.Name = "NitrogenoVegetal"
        Me.NitrogenoVegetal.Width = 55
        '
        'CarbonoOrganico
        '
        Me.CarbonoOrganico.HeaderText = "Carbono orgánico %"
        Me.CarbonoOrganico.Name = "CarbonoOrganico"
        Me.CarbonoOrganico.Width = 55
        '
        'MateriaOrganica
        '
        Me.MateriaOrganica.HeaderText = "Materia orgánica %"
        Me.MateriaOrganica.Name = "MateriaOrganica"
        Me.MateriaOrganica.Width = 55
        '
        'PMN
        '
        Me.PMN.HeaderText = "PMN"
        Me.PMN.Name = "PMN"
        Me.PMN.Width = 55
        '
        'Calcio
        '
        Me.Calcio.HeaderText = "Calcio"
        Me.Calcio.Name = "Calcio"
        Me.Calcio.Width = 55
        '
        'Magnesio
        '
        Me.Magnesio.HeaderText = "Magnesio"
        Me.Magnesio.Name = "Magnesio"
        Me.Magnesio.Width = 55
        '
        'Sodio
        '
        Me.Sodio.HeaderText = "Sodio"
        Me.Sodio.Name = "Sodio"
        Me.Sodio.Width = 55
        '
        'AcidezTitulable
        '
        Me.AcidezTitulable.HeaderText = "Acidéz Titulable"
        Me.AcidezTitulable.Name = "AcidezTitulable"
        Me.AcidezTitulable.Width = 55
        '
        'CIC
        '
        Me.CIC.HeaderText = "CIC"
        Me.CIC.Name = "CIC"
        Me.CIC.Width = 55
        '
        'SB
        '
        Me.SB.HeaderText = "SB %"
        Me.SB.Name = "SB"
        Me.SB.Width = 55
        '
        'DtDesde
        '
        Me.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtDesde.Location = New System.Drawing.Point(16, 89)
        Me.DtDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtDesde.Name = "DtDesde"
        Me.DtDesde.Size = New System.Drawing.Size(132, 22)
        Me.DtDesde.TabIndex = 24
        '
        'DtHasta
        '
        Me.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtHasta.Location = New System.Drawing.Point(156, 89)
        Me.DtHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtHasta.Name = "DtHasta"
        Me.DtHasta.Size = New System.Drawing.Size(132, 22)
        Me.DtHasta.TabIndex = 25
        '
        'BtnListar2020
        '
        Me.BtnListar2020.Location = New System.Drawing.Point(312, 89)
        Me.BtnListar2020.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnListar2020.Name = "BtnListar2020"
        Me.BtnListar2020.Size = New System.Drawing.Size(100, 28)
        Me.BtnListar2020.TabIndex = 26
        Me.BtnListar2020.Text = "Listar"
        Me.BtnListar2020.UseVisualStyleBackColor = True
        '
        'BtnExcelExportar
        '
        Me.BtnExcelExportar.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.BtnExcelExportar.Location = New System.Drawing.Point(420, 89)
        Me.BtnExcelExportar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnExcelExportar.Name = "BtnExcelExportar"
        Me.BtnExcelExportar.Size = New System.Drawing.Size(100, 28)
        Me.BtnExcelExportar.TabIndex = 27
        Me.BtnExcelExportar.UseVisualStyleBackColor = True
        '
        'FormEstadisticaSuelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1392, 752)
        Me.Controls.Add(Me.BtnExcelExportar)
        Me.Controls.Add(Me.BtnListar2020)
        Me.Controls.Add(Me.DtHasta)
        Me.Controls.Add(Me.DtDesde)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormEstadisticaSuelos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadística Suelos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FosforoBray As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FosforoCitrico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nitratos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pHAgua As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pHKCI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PotasioIntercambiable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sulfatos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NitrogenoVegetal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonoOrganico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MateriaOrganica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Calcio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Magnesio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sodio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcidezTitulable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnListar2020 As System.Windows.Forms.Button
    Friend WithEvents BtnExcelExportar As System.Windows.Forms.Button
End Class
