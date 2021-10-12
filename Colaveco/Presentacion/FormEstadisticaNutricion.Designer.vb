<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticaNutricion
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboClase = New System.Windows.Forms.ComboBox
        Me.ComboAlimento = New System.Windows.Forms.ComboBox
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ButtonExportar = New System.Windows.Forms.Button
        Me.CheckClaseAlimento = New System.Windows.Forms.CheckBox
        Me.CheckAlimento = New System.Windows.Forms.CheckBox
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Clase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Alimento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CenizasH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CenizasS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PBH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PBS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FNDH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FNDS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FADH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FADS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ENL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FCH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FCS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EEH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NIDA = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(14, 26)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(100, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(120, 26)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(100, 20)
        Me.DateHasta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'ComboClase
        '
        Me.ComboClase.FormattingEnabled = True
        Me.ComboClase.Location = New System.Drawing.Point(226, 25)
        Me.ComboClase.Name = "ComboClase"
        Me.ComboClase.Size = New System.Drawing.Size(206, 21)
        Me.ComboClase.TabIndex = 4
        '
        'ComboAlimento
        '
        Me.ComboAlimento.FormattingEnabled = True
        Me.ComboAlimento.Location = New System.Drawing.Point(438, 25)
        Me.ComboAlimento.Name = "ComboAlimento"
        Me.ComboAlimento.Size = New System.Drawing.Size(206, 21)
        Me.ComboAlimento.TabIndex = 5
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(664, 23)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 8
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Ficha, Me.Fecha, Me.Clase, Me.Alimento, Me.MS, Me.CenizasH, Me.CenizasS, Me.PBH, Me.PBS, Me.FNDH, Me.FNDS, Me.FADH, Me.FADS, Me.ENL, Me.EM, Me.FCH, Me.FCS, Me.PH, Me.EEH, Me.EES, Me.NIDA})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 64)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1288, 494)
        Me.DataGridView1.TabIndex = 10
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.ButtonExportar.Location = New System.Drawing.Point(745, 23)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportar.TabIndex = 11
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'CheckClaseAlimento
        '
        Me.CheckClaseAlimento.AutoSize = True
        Me.CheckClaseAlimento.Location = New System.Drawing.Point(226, 5)
        Me.CheckClaseAlimento.Name = "CheckClaseAlimento"
        Me.CheckClaseAlimento.Size = New System.Drawing.Size(109, 17)
        Me.CheckClaseAlimento.TabIndex = 12
        Me.CheckClaseAlimento.Text = "Clase de alimento"
        Me.CheckClaseAlimento.UseVisualStyleBackColor = True
        '
        'CheckAlimento
        '
        Me.CheckAlimento.AutoSize = True
        Me.CheckAlimento.Location = New System.Drawing.Point(438, 6)
        Me.CheckAlimento.Name = "CheckAlimento"
        Me.CheckAlimento.Size = New System.Drawing.Size(66, 17)
        Me.CheckAlimento.TabIndex = 13
        Me.CheckAlimento.Text = "Alimento"
        Me.CheckAlimento.UseVisualStyleBackColor = True
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
        Me.Ficha.Width = 60
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Clase
        '
        Me.Clase.HeaderText = "Clase"
        Me.Clase.Name = "Clase"
        '
        'Alimento
        '
        Me.Alimento.HeaderText = "Alimento"
        Me.Alimento.Name = "Alimento"
        '
        'MS
        '
        Me.MS.HeaderText = "% MS 105ºC"
        Me.MS.Name = "MS"
        Me.MS.Width = 60
        '
        'CenizasH
        '
        Me.CenizasH.HeaderText = "% Cenizas (H)"
        Me.CenizasH.Name = "CenizasH"
        Me.CenizasH.Width = 60
        '
        'CenizasS
        '
        Me.CenizasS.HeaderText = "% Cenizas (S)"
        Me.CenizasS.Name = "CenizasS"
        Me.CenizasS.Width = 60
        '
        'PBH
        '
        Me.PBH.HeaderText = "% PB (H)"
        Me.PBH.Name = "PBH"
        Me.PBH.Width = 60
        '
        'PBS
        '
        Me.PBS.HeaderText = "% PB (S)"
        Me.PBS.Name = "PBS"
        Me.PBS.Width = 60
        '
        'FNDH
        '
        Me.FNDH.HeaderText = "% FND (H)"
        Me.FNDH.Name = "FNDH"
        Me.FNDH.Width = 60
        '
        'FNDS
        '
        Me.FNDS.HeaderText = "% FND (S)"
        Me.FNDS.Name = "FNDS"
        Me.FNDS.Width = 60
        '
        'FADH
        '
        Me.FADH.HeaderText = "% FAD (H)"
        Me.FADH.Name = "FADH"
        Me.FADH.Width = 60
        '
        'FADS
        '
        Me.FADS.HeaderText = "% FAD (S)"
        Me.FADS.Name = "FADS"
        Me.FADS.Width = 60
        '
        'ENL
        '
        Me.ENL.HeaderText = "ENL (Mcal/Kg MS)"
        Me.ENL.Name = "ENL"
        Me.ENL.Width = 60
        '
        'EM
        '
        Me.EM.HeaderText = "EM (Mcal/Kg MS)"
        Me.EM.Name = "EM"
        Me.EM.Width = 60
        '
        'FCH
        '
        Me.FCH.HeaderText = "% FC (H)"
        Me.FCH.Name = "FCH"
        Me.FCH.Width = 60
        '
        'FCS
        '
        Me.FCS.HeaderText = "% FC (S)"
        Me.FCS.Name = "FCS"
        Me.FCS.Width = 60
        '
        'PH
        '
        Me.PH.HeaderText = "pH"
        Me.PH.Name = "PH"
        Me.PH.Width = 60
        '
        'EEH
        '
        Me.EEH.HeaderText = "% EE (H)"
        Me.EEH.Name = "EEH"
        Me.EEH.Width = 60
        '
        'EES
        '
        Me.EES.HeaderText = "% EE (S)"
        Me.EES.Name = "EES"
        Me.EES.Width = 60
        '
        'NIDA
        '
        Me.NIDA.HeaderText = "% NIDA"
        Me.NIDA.Name = "NIDA"
        Me.NIDA.Width = 60
        '
        'FormEstadisticaNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 568)
        Me.Controls.Add(Me.CheckAlimento)
        Me.Controls.Add(Me.CheckClaseAlimento)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.ComboAlimento)
        Me.Controls.Add(Me.ComboClase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormEstadisticaNutricion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadísticas de nutrición"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboClase As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAlimento As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
    Friend WithEvents CheckClaseAlimento As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAlimento As System.Windows.Forms.CheckBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alimento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CenizasH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CenizasS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PBH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PBS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNDH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FADH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FADS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EEH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIDA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
