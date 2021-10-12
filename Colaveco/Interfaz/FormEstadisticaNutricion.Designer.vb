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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboClase = New System.Windows.Forms.ComboBox()
        Me.ComboAlimento = New System.Windows.Forms.ComboBox()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CenizasS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PBS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FNDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FADS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AFLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonExportar = New System.Windows.Forms.Button()
        Me.CheckClaseAlimento = New System.Windows.Forms.CheckBox()
        Me.CheckAlimento = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateDesde2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateHasta2 = New System.Windows.Forms.DateTimePicker()
        Me.CheckClaseAlimento2 = New System.Windows.Forms.CheckBox()
        Me.ComboClase2 = New System.Windows.Forms.ComboBox()
        Me.CheckAlimento2 = New System.Windows.Forms.CheckBox()
        Me.ComboAlimento2 = New System.Windows.Forms.ComboBox()
        Me.ButtonListar2 = New System.Windows.Forms.Button()
        Me.ButtonExportar2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(19, 32)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(132, 22)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(160, 32)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(132, 22)
        Me.DateHasta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'ComboClase
        '
        Me.ComboClase.FormattingEnabled = True
        Me.ComboClase.Location = New System.Drawing.Point(301, 31)
        Me.ComboClase.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboClase.Name = "ComboClase"
        Me.ComboClase.Size = New System.Drawing.Size(273, 24)
        Me.ComboClase.TabIndex = 4
        '
        'ComboAlimento
        '
        Me.ComboAlimento.FormattingEnabled = True
        Me.ComboAlimento.Location = New System.Drawing.Point(584, 31)
        Me.ComboAlimento.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboAlimento.Name = "ComboAlimento"
        Me.ComboAlimento.Size = New System.Drawing.Size(273, 24)
        Me.ComboAlimento.TabIndex = 5
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(885, 28)
        Me.ButtonListar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonListar.TabIndex = 8
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Ficha, Me.Fecha, Me.MS, Me.CenizasS, Me.PBS, Me.FNDS, Me.FADS, Me.ENL, Me.EM, Me.FCS, Me.PH, Me.EES, Me.NIDA, Me.DON, Me.AFLA, Me.ZEA})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 169)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1473, 515)
        Me.DataGridView1.TabIndex = 10
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
        'MS
        '
        Me.MS.HeaderText = "% MS 105ºC"
        Me.MS.Name = "MS"
        Me.MS.Width = 60
        '
        'CenizasS
        '
        Me.CenizasS.HeaderText = "% Cenizas (S)"
        Me.CenizasS.Name = "CenizasS"
        Me.CenizasS.Width = 60
        '
        'PBS
        '
        Me.PBS.HeaderText = "% PB (S)"
        Me.PBS.Name = "PBS"
        Me.PBS.Width = 60
        '
        'FNDS
        '
        Me.FNDS.HeaderText = "% FND (S)"
        Me.FNDS.Name = "FNDS"
        Me.FNDS.Width = 60
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
        'DON
        '
        Me.DON.HeaderText = "DON(PPB)"
        Me.DON.Name = "DON"
        '
        'AFLA
        '
        Me.AFLA.HeaderText = "AFLA(PPB)"
        Me.AFLA.Name = "AFLA"
        '
        'ZEA
        '
        Me.ZEA.HeaderText = "ZEA(PPB)"
        Me.ZEA.Name = "ZEA"
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.ButtonExportar.Location = New System.Drawing.Point(993, 28)
        Me.ButtonExportar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonExportar.TabIndex = 11
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'CheckClaseAlimento
        '
        Me.CheckClaseAlimento.AutoSize = True
        Me.CheckClaseAlimento.Location = New System.Drawing.Point(301, 6)
        Me.CheckClaseAlimento.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckClaseAlimento.Name = "CheckClaseAlimento"
        Me.CheckClaseAlimento.Size = New System.Drawing.Size(142, 21)
        Me.CheckClaseAlimento.TabIndex = 12
        Me.CheckClaseAlimento.Text = "Clase de alimento"
        Me.CheckClaseAlimento.UseVisualStyleBackColor = True
        '
        'CheckAlimento
        '
        Me.CheckAlimento.AutoSize = True
        Me.CheckAlimento.Location = New System.Drawing.Point(584, 7)
        Me.CheckAlimento.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckAlimento.Name = "CheckAlimento"
        Me.CheckAlimento.Size = New System.Drawing.Size(84, 21)
        Me.CheckAlimento.TabIndex = 13
        Me.CheckAlimento.Text = "Alimento"
        Me.CheckAlimento.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "A partir del 2020"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 100)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Desde"
        '
        'DateDesde2
        '
        Me.DateDesde2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde2.Location = New System.Drawing.Point(18, 121)
        Me.DateDesde2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateDesde2.Name = "DateDesde2"
        Me.DateDesde2.Size = New System.Drawing.Size(132, 22)
        Me.DateDesde2.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(160, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Hasta"
        '
        'DateHasta2
        '
        Me.DateHasta2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta2.Location = New System.Drawing.Point(163, 121)
        Me.DateHasta2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateHasta2.Name = "DateHasta2"
        Me.DateHasta2.Size = New System.Drawing.Size(132, 22)
        Me.DateHasta2.TabIndex = 18
        '
        'CheckClaseAlimento2
        '
        Me.CheckClaseAlimento2.AutoSize = True
        Me.CheckClaseAlimento2.Location = New System.Drawing.Point(301, 96)
        Me.CheckClaseAlimento2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckClaseAlimento2.Name = "CheckClaseAlimento2"
        Me.CheckClaseAlimento2.Size = New System.Drawing.Size(142, 21)
        Me.CheckClaseAlimento2.TabIndex = 19
        Me.CheckClaseAlimento2.Text = "Clase de alimento"
        Me.CheckClaseAlimento2.UseVisualStyleBackColor = True
        '
        'ComboClase2
        '
        Me.ComboClase2.FormattingEnabled = True
        Me.ComboClase2.Location = New System.Drawing.Point(301, 119)
        Me.ComboClase2.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboClase2.Name = "ComboClase2"
        Me.ComboClase2.Size = New System.Drawing.Size(273, 24)
        Me.ComboClase2.TabIndex = 20
        '
        'CheckAlimento2
        '
        Me.CheckAlimento2.AutoSize = True
        Me.CheckAlimento2.Location = New System.Drawing.Point(584, 96)
        Me.CheckAlimento2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckAlimento2.Name = "CheckAlimento2"
        Me.CheckAlimento2.Size = New System.Drawing.Size(84, 21)
        Me.CheckAlimento2.TabIndex = 21
        Me.CheckAlimento2.Text = "Alimento"
        Me.CheckAlimento2.UseVisualStyleBackColor = True
        '
        'ComboAlimento2
        '
        Me.ComboAlimento2.FormattingEnabled = True
        Me.ComboAlimento2.Location = New System.Drawing.Point(584, 119)
        Me.ComboAlimento2.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboAlimento2.Name = "ComboAlimento2"
        Me.ComboAlimento2.Size = New System.Drawing.Size(273, 24)
        Me.ComboAlimento2.TabIndex = 22
        '
        'ButtonListar2
        '
        Me.ButtonListar2.Location = New System.Drawing.Point(885, 115)
        Me.ButtonListar2.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonListar2.Name = "ButtonListar2"
        Me.ButtonListar2.Size = New System.Drawing.Size(100, 28)
        Me.ButtonListar2.TabIndex = 23
        Me.ButtonListar2.Text = "Listar"
        Me.ButtonListar2.UseVisualStyleBackColor = True
        '
        'ButtonExportar2
        '
        Me.ButtonExportar2.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.ButtonExportar2.Location = New System.Drawing.Point(993, 115)
        Me.ButtonExportar2.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonExportar2.Name = "ButtonExportar2"
        Me.ButtonExportar2.Size = New System.Drawing.Size(100, 28)
        Me.ButtonExportar2.TabIndex = 24
        Me.ButtonExportar2.UseVisualStyleBackColor = True
        '
        'FormEstadisticaNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1421, 813)
        Me.Controls.Add(Me.ButtonExportar2)
        Me.Controls.Add(Me.ButtonListar2)
        Me.Controls.Add(Me.ComboAlimento2)
        Me.Controls.Add(Me.CheckAlimento2)
        Me.Controls.Add(Me.ComboClase2)
        Me.Controls.Add(Me.CheckClaseAlimento2)
        Me.Controls.Add(Me.DateHasta2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateDesde2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateDesde2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateHasta2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckClaseAlimento2 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboClase2 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckAlimento2 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboAlimento2 As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonListar2 As System.Windows.Forms.Button
    Friend WithEvents ButtonExportar2 As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CenizasS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PBS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FADS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AFLA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZEA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
