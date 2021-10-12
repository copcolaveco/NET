<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab88
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.ComboEliminado = New System.Windows.Forms.ComboBox
        Me.TextDelta = New System.Windows.Forms.TextBox
        Me.TextCrioscopo = New System.Windows.Forms.TextBox
        Me.ComboOperador = New System.Windows.Forms.ComboBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.TextHora = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestra2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonExcel = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Ficha})
        Me.DataGridView1.Location = New System.Drawing.Point(530, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(206, 404)
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
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(243, 393)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 70
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(162, 393)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 69
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(81, 393)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 68
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 251)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Observaciones"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Eliminadas por:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Res. Delta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Res. Crióscopo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Operador"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Muestra"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Ficha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Hora"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Id"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(107, 248)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(183, 130)
        Me.TextObservaciones.TabIndex = 56
        '
        'ComboEliminado
        '
        Me.ComboEliminado.FormattingEnabled = True
        Me.ComboEliminado.Location = New System.Drawing.Point(107, 221)
        Me.ComboEliminado.Name = "ComboEliminado"
        Me.ComboEliminado.Size = New System.Drawing.Size(183, 21)
        Me.ComboEliminado.TabIndex = 55
        '
        'TextDelta
        '
        Me.TextDelta.Location = New System.Drawing.Point(107, 168)
        Me.TextDelta.Name = "TextDelta"
        Me.TextDelta.Size = New System.Drawing.Size(75, 20)
        Me.TextDelta.TabIndex = 54
        '
        'TextCrioscopo
        '
        Me.TextCrioscopo.Location = New System.Drawing.Point(107, 142)
        Me.TextCrioscopo.Name = "TextCrioscopo"
        Me.TextCrioscopo.Size = New System.Drawing.Size(75, 20)
        Me.TextCrioscopo.TabIndex = 53
        '
        'ComboOperador
        '
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(107, 194)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(183, 21)
        Me.ComboOperador.TabIndex = 52
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(107, 116)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(75, 20)
        Me.TextMuestra.TabIndex = 50
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(107, 90)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(75, 20)
        Me.TextFicha.TabIndex = 49
        '
        'TextHora
        '
        Me.TextHora.Location = New System.Drawing.Point(107, 64)
        Me.TextHora.Name = "TextHora"
        Me.TextHora.Size = New System.Drawing.Size(75, 20)
        Me.TextHora.TabIndex = 48
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(107, 38)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 47
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(107, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 46
        '
        'Timer1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(337, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(155, 23)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "Importar archivos de calidad"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Ficha2, Me.Muestra2})
        Me.DataGridView2.Location = New System.Drawing.Point(337, 41)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(187, 334)
        Me.DataGridView2.TabIndex = 73
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Ficha2
        '
        Me.Ficha2.HeaderText = "Ficha"
        Me.Ficha2.Name = "Ficha2"
        Me.Ficha2.Width = 80
        '
        'Muestra2
        '
        Me.Muestra2.HeaderText = "Muestra"
        Me.Muestra2.Name = "Muestra2"
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Location = New System.Drawing.Point(420, 393)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(104, 23)
        Me.ButtonExcel.TabIndex = 74
        Me.ButtonExcel.Text = "Exportar a Excel"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'FormRgLab88
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 439)
        Me.Controls.Add(Me.ButtonExcel)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.ComboEliminado)
        Me.Controls.Add(Me.TextDelta)
        Me.Controls.Add(Me.TextCrioscopo)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.TextHora)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormRgLab88"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla diaria de análisis - Crióscopo Advanced (RG.LAB 88)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents ComboEliminado As System.Windows.Forms.ComboBox
    Friend WithEvents TextDelta As System.Windows.Forms.TextBox
    Friend WithEvents TextCrioscopo As System.Windows.Forms.TextBox
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextHora As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
End Class
