<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSecale
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.RadioColaveco = New System.Windows.Forms.RadioButton
        Me.RadioSecale = New System.Windows.Forms.RadioButton
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.TextGrasa = New System.Windows.Forms.TextBox
        Me.TextProteina = New System.Windows.Forms.TextBox
        Me.TextLactosa = New System.Windows.Forms.TextBox
        Me.TextST = New System.Windows.Forms.TextBox
        Me.TextRC = New System.Windows.Forms.TextBox
        Me.TextRB = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextRBPetri = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Empresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grasa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proteina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lactosa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SolTotales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RB2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(12, 12)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(103, 20)
        Me.DateFecha.TabIndex = 10
        '
        'RadioColaveco
        '
        Me.RadioColaveco.AutoSize = True
        Me.RadioColaveco.Location = New System.Drawing.Point(90, 48)
        Me.RadioColaveco.Name = "RadioColaveco"
        Me.RadioColaveco.Size = New System.Drawing.Size(70, 17)
        Me.RadioColaveco.TabIndex = 12
        Me.RadioColaveco.TabStop = True
        Me.RadioColaveco.Text = "Colaveco"
        Me.RadioColaveco.UseVisualStyleBackColor = True
        '
        'RadioSecale
        '
        Me.RadioSecale.AutoSize = True
        Me.RadioSecale.Location = New System.Drawing.Point(90, 71)
        Me.RadioSecale.Name = "RadioSecale"
        Me.RadioSecale.Size = New System.Drawing.Size(58, 17)
        Me.RadioSecale.TabIndex = 13
        Me.RadioSecale.TabStop = True
        Me.RadioSecale.Text = "Secale"
        Me.RadioSecale.UseVisualStyleBackColor = True
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(90, 104)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(70, 20)
        Me.TextMuestra.TabIndex = 0
        '
        'TextGrasa
        '
        Me.TextGrasa.Location = New System.Drawing.Point(90, 130)
        Me.TextGrasa.Name = "TextGrasa"
        Me.TextGrasa.Size = New System.Drawing.Size(70, 20)
        Me.TextGrasa.TabIndex = 1
        '
        'TextProteina
        '
        Me.TextProteina.Location = New System.Drawing.Point(90, 156)
        Me.TextProteina.Name = "TextProteina"
        Me.TextProteina.Size = New System.Drawing.Size(70, 20)
        Me.TextProteina.TabIndex = 2
        '
        'TextLactosa
        '
        Me.TextLactosa.Location = New System.Drawing.Point(90, 182)
        Me.TextLactosa.Name = "TextLactosa"
        Me.TextLactosa.Size = New System.Drawing.Size(70, 20)
        Me.TextLactosa.TabIndex = 3
        '
        'TextST
        '
        Me.TextST.Location = New System.Drawing.Point(90, 208)
        Me.TextST.Name = "TextST"
        Me.TextST.Size = New System.Drawing.Size(70, 20)
        Me.TextST.TabIndex = 4
        '
        'TextRC
        '
        Me.TextRC.Location = New System.Drawing.Point(90, 234)
        Me.TextRC.Name = "TextRC"
        Me.TextRC.Size = New System.Drawing.Size(70, 20)
        Me.TextRC.TabIndex = 5
        '
        'TextRB
        '
        Me.TextRB.Location = New System.Drawing.Point(90, 260)
        Me.TextRB.Name = "TextRB"
        Me.TextRB.Size = New System.Drawing.Size(70, 20)
        Me.TextRB.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Muestra"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Grasa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Proteína"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Lactosa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Sólidos totales"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "RC"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "RB"
        '
        'TextRBPetri
        '
        Me.TextRBPetri.Location = New System.Drawing.Point(90, 286)
        Me.TextRBPetri.Name = "TextRBPetri"
        Me.TextRBPetri.Size = New System.Drawing.Size(70, 20)
        Me.TextRBPetri.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 289)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "RB (Petri)"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Empresa, Me.Muestra, Me.Grasa, Me.Proteina, Me.Lactosa, Me.SolTotales, Me.RC, Me.RB, Me.RB2})
        Me.DataGridView1.Location = New System.Drawing.Point(192, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(710, 422)
        Me.DataGridView1.TabIndex = 14
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Empresa
        '
        Me.Empresa.HeaderText = "Empresa"
        Me.Empresa.Name = "Empresa"
        '
        'Muestra
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Muestra.DefaultCellStyle = DataGridViewCellStyle1
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        '
        'Grasa
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Grasa.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grasa.HeaderText = "Grasa"
        Me.Grasa.Name = "Grasa"
        Me.Grasa.Width = 60
        '
        'Proteina
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Proteina.DefaultCellStyle = DataGridViewCellStyle3
        Me.Proteina.HeaderText = "Proteína"
        Me.Proteina.Name = "Proteina"
        Me.Proteina.Width = 60
        '
        'Lactosa
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Lactosa.DefaultCellStyle = DataGridViewCellStyle4
        Me.Lactosa.HeaderText = "Lactosa"
        Me.Lactosa.Name = "Lactosa"
        Me.Lactosa.Width = 60
        '
        'SolTotales
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SolTotales.DefaultCellStyle = DataGridViewCellStyle5
        Me.SolTotales.HeaderText = "S. Totales"
        Me.SolTotales.Name = "SolTotales"
        Me.SolTotales.Width = 65
        '
        'RC
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RC.DefaultCellStyle = DataGridViewCellStyle6
        Me.RC.HeaderText = "RC"
        Me.RC.Name = "RC"
        Me.RC.Width = 60
        '
        'RB
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RB.DefaultCellStyle = DataGridViewCellStyle7
        Me.RB.HeaderText = "RB"
        Me.RB.Name = "RB"
        Me.RB.Width = 60
        '
        'RB2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RB2.DefaultCellStyle = DataGridViewCellStyle8
        Me.RB2.HeaderText = "RB (Petri)"
        Me.RB2.Name = "RB2"
        Me.RB2.Width = 60
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(12, 325)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 9
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(93, 325)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 8
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(12, 71)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(54, 20)
        Me.TextId.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Id"
        '
        'FormSecale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 446)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextRBPetri)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextRB)
        Me.Controls.Add(Me.TextRC)
        Me.Controls.Add(Me.TextST)
        Me.Controls.Add(Me.TextLactosa)
        Me.Controls.Add(Me.TextProteina)
        Me.Controls.Add(Me.TextGrasa)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.RadioSecale)
        Me.Controls.Add(Me.RadioColaveco)
        Me.Controls.Add(Me.DateFecha)
        Me.Name = "FormSecale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colaveco - Secale"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioColaveco As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSecale As System.Windows.Forms.RadioButton
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextGrasa As System.Windows.Forms.TextBox
    Friend WithEvents TextProteina As System.Windows.Forms.TextBox
    Friend WithEvents TextLactosa As System.Windows.Forms.TextBox
    Friend WithEvents TextST As System.Windows.Forms.TextBox
    Friend WithEvents TextRC As System.Windows.Forms.TextBox
    Friend WithEvents TextRB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextRBPetri As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grasa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proteina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lactosa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SolTotales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RB2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
