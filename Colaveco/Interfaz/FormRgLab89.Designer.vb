<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab89
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
        Me.components = New System.ComponentModel.Container
        Me.Label12 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Media = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Resultado1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Resultado2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.ComboOperador = New System.Windows.Forms.ComboBox
        Me.TextResultado1 = New System.Windows.Forms.TextBox
        Me.TextMedia = New System.Windows.Forms.TextBox
        Me.TextHora = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextResultado2 = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextC1 = New System.Windows.Forms.TextBox
        Me.TextC2 = New System.Windows.Forms.TextBox
        Me.ButtonGuardarMedias = New System.Windows.Forms.Button
        Me.TextDiferencia = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.RadioC1 = New System.Windows.Forms.RadioButton
        Me.RadioC2 = New System.Windows.Forms.RadioButton
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 74
        Me.Label12.Text = "Muestra"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Muestra, Me.Media, Me.Resultado1, Me.Resultado2})
        Me.DataGridView1.Location = New System.Drawing.Point(315, 43)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(507, 416)
        Me.DataGridView1.TabIndex = 71
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
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        '
        'Media
        '
        Me.Media.HeaderText = "Media"
        Me.Media.Name = "Media"
        '
        'Resultado1
        '
        Me.Resultado1.HeaderText = "Resultado 1"
        Me.Resultado1.Name = "Resultado1"
        '
        'Resultado2
        '
        Me.Resultado2.HeaderText = "Resultado 2"
        Me.Resultado2.Name = "Resultado2"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(204, 436)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 70
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(123, 436)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 69
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(42, 436)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 68
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 281)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Observaciones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Operador"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Resultado 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Resultado 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Media"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Hora"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Id"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(98, 278)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(183, 130)
        Me.TextObservaciones.TabIndex = 56
        '
        'ComboOperador
        '
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(98, 251)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(183, 21)
        Me.ComboOperador.TabIndex = 52
        '
        'TextResultado1
        '
        Me.TextResultado1.Location = New System.Drawing.Point(100, 147)
        Me.TextResultado1.Name = "TextResultado1"
        Me.TextResultado1.Size = New System.Drawing.Size(75, 20)
        Me.TextResultado1.TabIndex = 50
        '
        'TextMedia
        '
        Me.TextMedia.Location = New System.Drawing.Point(100, 199)
        Me.TextMedia.Name = "TextMedia"
        Me.TextMedia.ReadOnly = True
        Me.TextMedia.Size = New System.Drawing.Size(75, 20)
        Me.TextMedia.TabIndex = 49
        '
        'TextHora
        '
        Me.TextHora.Location = New System.Drawing.Point(100, 95)
        Me.TextHora.Name = "TextHora"
        Me.TextHora.Size = New System.Drawing.Size(75, 20)
        Me.TextHora.TabIndex = 48
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(100, 69)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 47
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(100, 43)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 46
        '
        'TextResultado2
        '
        Me.TextResultado2.Location = New System.Drawing.Point(100, 173)
        Me.TextResultado2.Name = "TextResultado2"
        Me.TextResultado2.Size = New System.Drawing.Size(75, 20)
        Me.TextResultado2.TabIndex = 76
        '
        'Timer1
        '
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Media Piloto"
        '
        'TextC1
        '
        Me.TextC1.Location = New System.Drawing.Point(100, 6)
        Me.TextC1.Name = "TextC1"
        Me.TextC1.Size = New System.Drawing.Size(56, 20)
        Me.TextC1.TabIndex = 78
        '
        'TextC2
        '
        Me.TextC2.Location = New System.Drawing.Point(162, 6)
        Me.TextC2.Name = "TextC2"
        Me.TextC2.Size = New System.Drawing.Size(56, 20)
        Me.TextC2.TabIndex = 79
        '
        'ButtonGuardarMedias
        '
        Me.ButtonGuardarMedias.Location = New System.Drawing.Point(224, 4)
        Me.ButtonGuardarMedias.Name = "ButtonGuardarMedias"
        Me.ButtonGuardarMedias.Size = New System.Drawing.Size(57, 23)
        Me.ButtonGuardarMedias.TabIndex = 80
        Me.ButtonGuardarMedias.Text = "Guardar"
        Me.ButtonGuardarMedias.UseVisualStyleBackColor = True
        '
        'TextDiferencia
        '
        Me.TextDiferencia.Location = New System.Drawing.Point(100, 225)
        Me.TextDiferencia.Name = "TextDiferencia"
        Me.TextDiferencia.ReadOnly = True
        Me.TextDiferencia.Size = New System.Drawing.Size(75, 20)
        Me.TextDiferencia.TabIndex = 81
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Diferencia"
        '
        'RadioC1
        '
        Me.RadioC1.AutoSize = True
        Me.RadioC1.Location = New System.Drawing.Point(98, 121)
        Me.RadioC1.Name = "RadioC1"
        Me.RadioC1.Size = New System.Drawing.Size(38, 17)
        Me.RadioC1.TabIndex = 83
        Me.RadioC1.TabStop = True
        Me.RadioC1.Text = "C1"
        Me.RadioC1.UseVisualStyleBackColor = True
        '
        'RadioC2
        '
        Me.RadioC2.AutoSize = True
        Me.RadioC2.Location = New System.Drawing.Point(137, 121)
        Me.RadioC2.Name = "RadioC2"
        Me.RadioC2.Size = New System.Drawing.Size(38, 17)
        Me.RadioC2.TabIndex = 84
        Me.RadioC2.TabStop = True
        Me.RadioC2.Text = "C2"
        Me.RadioC2.UseVisualStyleBackColor = True
        '
        'FormRgLab89
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 475)
        Me.Controls.Add(Me.RadioC2)
        Me.Controls.Add(Me.RadioC1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextDiferencia)
        Me.Controls.Add(Me.ButtonGuardarMedias)
        Me.Controls.Add(Me.TextC2)
        Me.Controls.Add(Me.TextC1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextResultado2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.TextResultado1)
        Me.Controls.Add(Me.TextMedia)
        Me.Controls.Add(Me.TextHora)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormRgLab89"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controles internos Crióscopo (RG.LAB 89)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents TextResultado1 As System.Windows.Forms.TextBox
    Friend WithEvents TextMedia As System.Windows.Forms.TextBox
    Friend WithEvents TextHora As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextResultado2 As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Media As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextC1 As System.Windows.Forms.TextBox
    Friend WithEvents TextC2 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGuardarMedias As System.Windows.Forms.Button
    Friend WithEvents TextDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadioC1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioC2 As System.Windows.Forms.RadioButton
End Class
