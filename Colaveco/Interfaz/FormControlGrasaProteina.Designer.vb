<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlGrasaProteina
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TextId = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBentleyG = New System.Windows.Forms.TextBox
        Me.TextBentleyP = New System.Windows.Forms.TextBox
        Me.TextDeltaP = New System.Windows.Forms.TextBox
        Me.TextDeltaG = New System.Windows.Forms.TextBox
        Me.TextDumasP = New System.Windows.Forms.TextBox
        Me.TextRoseGottliebG = New System.Windows.Forms.TextBox
        Me.TextKjeldahP = New System.Windows.Forms.TextBox
        Me.TextGerberG = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.TextOperador = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BentleyG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeltaG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoseGottliebG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GerberG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BentleyP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeltaP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DumasP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KjeldahP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Operador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(12, 27)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(53, 20)
        Me.TextId.TabIndex = 100
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(71, 27)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(107, 20)
        Me.DateFecha.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Grasa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Proteínas"
        '
        'TextBentleyG
        '
        Me.TextBentleyG.Location = New System.Drawing.Point(251, 27)
        Me.TextBentleyG.Name = "TextBentleyG"
        Me.TextBentleyG.Size = New System.Drawing.Size(100, 20)
        Me.TextBentleyG.TabIndex = 0
        Me.TextBentleyG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBentleyP
        '
        Me.TextBentleyP.Location = New System.Drawing.Point(251, 68)
        Me.TextBentleyP.Name = "TextBentleyP"
        Me.TextBentleyP.Size = New System.Drawing.Size(100, 20)
        Me.TextBentleyP.TabIndex = 4
        Me.TextBentleyP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextDeltaP
        '
        Me.TextDeltaP.Location = New System.Drawing.Point(357, 68)
        Me.TextDeltaP.Name = "TextDeltaP"
        Me.TextDeltaP.Size = New System.Drawing.Size(100, 20)
        Me.TextDeltaP.TabIndex = 5
        Me.TextDeltaP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextDeltaG
        '
        Me.TextDeltaG.Location = New System.Drawing.Point(357, 27)
        Me.TextDeltaG.Name = "TextDeltaG"
        Me.TextDeltaG.Size = New System.Drawing.Size(100, 20)
        Me.TextDeltaG.TabIndex = 1
        Me.TextDeltaG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextDumasP
        '
        Me.TextDumasP.Location = New System.Drawing.Point(463, 68)
        Me.TextDumasP.Name = "TextDumasP"
        Me.TextDumasP.Size = New System.Drawing.Size(100, 20)
        Me.TextDumasP.TabIndex = 6
        Me.TextDumasP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextRoseGottliebG
        '
        Me.TextRoseGottliebG.Location = New System.Drawing.Point(463, 27)
        Me.TextRoseGottliebG.Name = "TextRoseGottliebG"
        Me.TextRoseGottliebG.Size = New System.Drawing.Size(100, 20)
        Me.TextRoseGottliebG.TabIndex = 2
        Me.TextRoseGottliebG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextKjeldahP
        '
        Me.TextKjeldahP.Location = New System.Drawing.Point(569, 68)
        Me.TextKjeldahP.Name = "TextKjeldahP"
        Me.TextKjeldahP.Size = New System.Drawing.Size(100, 20)
        Me.TextKjeldahP.TabIndex = 7
        Me.TextKjeldahP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextGerberG
        '
        Me.TextGerberG.Location = New System.Drawing.Point(569, 27)
        Me.TextGerberG.Name = "TextGerberG"
        Me.TextGerberG.Size = New System.Drawing.Size(100, 20)
        Me.TextGerberG.TabIndex = 3
        Me.TextGerberG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(284, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Bentley"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(391, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Delta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(478, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Rose Gottlieb"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(599, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Gerber"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(762, 25)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 8
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextOperador
        '
        Me.TextOperador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextOperador.Location = New System.Drawing.Point(679, 11)
        Me.TextOperador.Name = "TextOperador"
        Me.TextOperador.ReadOnly = True
        Me.TextOperador.Size = New System.Drawing.Size(160, 13)
        Me.TextOperador.TabIndex = 18
        Me.TextOperador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.BentleyG, Me.DeltaG, Me.RoseGottliebG, Me.GerberG, Me.BentleyP, Me.DeltaP, Me.DumasP, Me.KjeldahP, Me.Operador})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(825, 405)
        Me.DataGridView1.TabIndex = 101
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle1
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'BentleyG
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BentleyG.DefaultCellStyle = DataGridViewCellStyle2
        Me.BentleyG.HeaderText = "Bentley  Grasa"
        Me.BentleyG.Name = "BentleyG"
        Me.BentleyG.Width = 80
        '
        'DeltaG
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DeltaG.DefaultCellStyle = DataGridViewCellStyle3
        Me.DeltaG.HeaderText = "Delta  Grasa"
        Me.DeltaG.Name = "DeltaG"
        Me.DeltaG.Width = 80
        '
        'RoseGottliebG
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RoseGottliebG.DefaultCellStyle = DataGridViewCellStyle4
        Me.RoseGottliebG.HeaderText = "RG  Grasa"
        Me.RoseGottliebG.Name = "RoseGottliebG"
        Me.RoseGottliebG.Width = 80
        '
        'GerberG
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GerberG.DefaultCellStyle = DataGridViewCellStyle5
        Me.GerberG.HeaderText = "Gerber  Grasa"
        Me.GerberG.Name = "GerberG"
        Me.GerberG.Width = 80
        '
        'BentleyP
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BentleyP.DefaultCellStyle = DataGridViewCellStyle6
        Me.BentleyP.HeaderText = "Bentley  Proteína"
        Me.BentleyP.Name = "BentleyP"
        Me.BentleyP.Width = 80
        '
        'DeltaP
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DeltaP.DefaultCellStyle = DataGridViewCellStyle7
        Me.DeltaP.HeaderText = "Delta  Proteína"
        Me.DeltaP.Name = "DeltaP"
        Me.DeltaP.Width = 80
        '
        'DumasP
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DumasP.DefaultCellStyle = DataGridViewCellStyle8
        Me.DumasP.HeaderText = "Dumas  Proteína"
        Me.DumasP.Name = "DumasP"
        Me.DumasP.Width = 80
        '
        'KjeldahP
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.KjeldahP.DefaultCellStyle = DataGridViewCellStyle9
        Me.KjeldahP.HeaderText = "Kjeldah  Proteína"
        Me.KjeldahP.Name = "KjeldahP"
        Me.KjeldahP.Width = 80
        '
        'Operador
        '
        Me.Operador.HeaderText = "Operador"
        Me.Operador.Name = "Operador"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(762, 54)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 102
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(762, 83)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 103
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(599, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Kjeldah"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(493, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Dumas"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(391, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Delta"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(284, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "Bentley"
        '
        'FormControlGrasaProteina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 529)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextOperador)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextKjeldahP)
        Me.Controls.Add(Me.TextGerberG)
        Me.Controls.Add(Me.TextDumasP)
        Me.Controls.Add(Me.TextRoseGottliebG)
        Me.Controls.Add(Me.TextDeltaP)
        Me.Controls.Add(Me.TextDeltaG)
        Me.Controls.Add(Me.TextBentleyP)
        Me.Controls.Add(Me.TextBentleyG)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormControlGrasaProteina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de grasa y proteínas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBentleyG As System.Windows.Forms.TextBox
    Friend WithEvents TextBentleyP As System.Windows.Forms.TextBox
    Friend WithEvents TextDeltaP As System.Windows.Forms.TextBox
    Friend WithEvents TextDeltaG As System.Windows.Forms.TextBox
    Friend WithEvents TextDumasP As System.Windows.Forms.TextBox
    Friend WithEvents TextRoseGottliebG As System.Windows.Forms.TextBox
    Friend WithEvents TextKjeldahP As System.Windows.Forms.TextBox
    Friend WithEvents TextGerberG As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextOperador As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BentleyG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeltaG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoseGottliebG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GerberG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BentleyP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeltaP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DumasP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KjeldahP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operador As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
