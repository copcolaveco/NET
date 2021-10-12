<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDescarteMuestras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDescarteMuestras))
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.ComboMuestra = New System.Windows.Forms.ComboBox()
        Me.TextCantidad = New System.Windows.Forms.TextBox()
        Me.ComboTipoInforme = New System.Windows.Forms.ComboBox()
        Me.ComboDescarte = New System.Windows.Forms.ComboBox()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.ComboRetorno = New System.Windows.Forms.ComboBox()
        Me.ComboAutorizacion = New System.Windows.Forms.ComboBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(137, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(68, 20)
        Me.TextId.TabIndex = 0
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(137, 38)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 1
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(137, 64)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(68, 20)
        Me.TextFicha.TabIndex = 2
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(137, 90)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(68, 20)
        Me.TextIdProductor.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(211, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "^"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(235, 90)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(283, 20)
        Me.TextProductor.TabIndex = 5
        '
        'ComboMuestra
        '
        Me.ComboMuestra.FormattingEnabled = True
        Me.ComboMuestra.Location = New System.Drawing.Point(137, 146)
        Me.ComboMuestra.Name = "ComboMuestra"
        Me.ComboMuestra.Size = New System.Drawing.Size(121, 21)
        Me.ComboMuestra.TabIndex = 6
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(137, 173)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(56, 20)
        Me.TextCantidad.TabIndex = 7
        '
        'ComboTipoInforme
        '
        Me.ComboTipoInforme.FormattingEnabled = True
        Me.ComboTipoInforme.Location = New System.Drawing.Point(137, 116)
        Me.ComboTipoInforme.Name = "ComboTipoInforme"
        Me.ComboTipoInforme.Size = New System.Drawing.Size(122, 21)
        Me.ComboTipoInforme.TabIndex = 8
        '
        'ComboDescarte
        '
        Me.ComboDescarte.FormattingEnabled = True
        Me.ComboDescarte.Location = New System.Drawing.Point(137, 199)
        Me.ComboDescarte.Name = "ComboDescarte"
        Me.ComboDescarte.Size = New System.Drawing.Size(121, 21)
        Me.ComboDescarte.TabIndex = 9
        '
        'TextValor
        '
        Me.TextValor.Location = New System.Drawing.Point(137, 226)
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(56, 20)
        Me.TextValor.TabIndex = 10
        '
        'ComboRetorno
        '
        Me.ComboRetorno.FormattingEnabled = True
        Me.ComboRetorno.Location = New System.Drawing.Point(137, 252)
        Me.ComboRetorno.Name = "ComboRetorno"
        Me.ComboRetorno.Size = New System.Drawing.Size(121, 21)
        Me.ComboRetorno.TabIndex = 11
        '
        'ComboAutorizacion
        '
        Me.ComboAutorizacion.FormattingEnabled = True
        Me.ComboAutorizacion.Location = New System.Drawing.Point(137, 279)
        Me.ComboAutorizacion.Name = "ComboAutorizacion"
        Me.ComboAutorizacion.Size = New System.Drawing.Size(121, 21)
        Me.ComboAutorizacion.TabIndex = 12
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(137, 306)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(381, 88)
        Me.TextObservaciones.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Ficha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Productor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Muestra"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Cantidad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Tipo de informe"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Motivo descarte"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Valor/Temp."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 255)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Información de retorno"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Autorización"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 318)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Observaciones"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(137, 400)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 27
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(218, 400)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 26
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(443, 9)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 28
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'FormDescarteMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 438)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.ComboAutorizacion)
        Me.Controls.Add(Me.ComboRetorno)
        Me.Controls.Add(Me.TextValor)
        Me.Controls.Add(Me.ComboDescarte)
        Me.Controls.Add(Me.ComboTipoInforme)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.ComboMuestra)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormDescarteMuestras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RG.ADM.09 v04 21/03/2012 - Descarte de muestras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents ComboMuestra As System.Windows.Forms.ComboBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents ComboDescarte As System.Windows.Forms.ComboBox
    Friend WithEvents TextValor As System.Windows.Forms.TextBox
    Friend WithEvents ComboRetorno As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAutorizacion As System.Windows.Forms.ComboBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
End Class
