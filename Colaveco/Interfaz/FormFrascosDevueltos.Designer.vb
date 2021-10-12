<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFrascosDevueltos
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
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ListFrascosDevueltos = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextIdCliente = New System.Windows.Forms.TextBox
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.TextNombreCliente = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextOtros = New System.Windows.Forms.TextBox
        Me.TextEsteriles = New System.Windows.Forms.TextBox
        Me.TextSangre = New System.Windows.Forms.TextBox
        Me.TextAgua = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextRC_compos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(177, 354)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 11
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(96, 354)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 9
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(15, 354)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 10
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ListFrascosDevueltos
        '
        Me.ListFrascosDevueltos.BackColor = System.Drawing.SystemColors.Info
        Me.ListFrascosDevueltos.FormattingEnabled = True
        Me.ListFrascosDevueltos.Location = New System.Drawing.Point(416, 6)
        Me.ListFrascosDevueltos.Name = "ListFrascosDevueltos"
        Me.ListFrascosDevueltos.Size = New System.Drawing.Size(290, 342)
        Me.ListFrascosDevueltos.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Id"
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(96, 32)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 1
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(96, 6)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(66, 20)
        Me.TextId.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Cliente"
        '
        'TextIdCliente
        '
        Me.TextIdCliente.Location = New System.Drawing.Point(96, 87)
        Me.TextIdCliente.Name = "TextIdCliente"
        Me.TextIdCliente.ReadOnly = True
        Me.TextIdCliente.Size = New System.Drawing.Size(58, 20)
        Me.TextIdCliente.TabIndex = 18
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(160, 87)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(14, 20)
        Me.ButtonBuscar.TabIndex = 19
        Me.ButtonBuscar.Text = "^"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'TextNombreCliente
        '
        Me.TextNombreCliente.Location = New System.Drawing.Point(180, 88)
        Me.TextNombreCliente.Name = "TextNombreCliente"
        Me.TextNombreCliente.ReadOnly = True
        Me.TextNombreCliente.Size = New System.Drawing.Size(230, 20)
        Me.TextNombreCliente.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 224)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Otros"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 198)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Estériles"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Sangre"
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(96, 217)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(78, 20)
        Me.TextOtros.TabIndex = 7
        '
        'TextEsteriles
        '
        Me.TextEsteriles.Location = New System.Drawing.Point(96, 191)
        Me.TextEsteriles.Name = "TextEsteriles"
        Me.TextEsteriles.Size = New System.Drawing.Size(78, 20)
        Me.TextEsteriles.TabIndex = 6
        '
        'TextSangre
        '
        Me.TextSangre.Location = New System.Drawing.Point(96, 165)
        Me.TextSangre.Name = "TextSangre"
        Me.TextSangre.Size = New System.Drawing.Size(78, 20)
        Me.TextSangre.TabIndex = 5
        '
        'TextAgua
        '
        Me.TextAgua.Location = New System.Drawing.Point(96, 139)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.Size = New System.Drawing.Size(78, 20)
        Me.TextAgua.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Agua"
        '
        'TextRC_compos
        '
        Me.TextRC_compos.Location = New System.Drawing.Point(96, 113)
        Me.TextRC_compos.Name = "TextRC_compos"
        Me.TextRC_compos.Size = New System.Drawing.Size(78, 20)
        Me.TextRC_compos.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "RC Compos."
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(96, 243)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(314, 105)
        Me.TextObservaciones.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Ficha"
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(96, 58)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(66, 20)
        Me.TextFicha.TabIndex = 2
        '
        'FormFrascosDevueltos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 396)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextOtros)
        Me.Controls.Add(Me.TextEsteriles)
        Me.Controls.Add(Me.TextSangre)
        Me.Controls.Add(Me.TextAgua)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextRC_compos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextNombreCliente)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.TextIdCliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListFrascosDevueltos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormFrascosDevueltos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frascos devueltos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ListFrascosDevueltos As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents TextNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextEsteriles As System.Windows.Forms.TextBox
    Friend WithEvents TextSangre As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextRC_compos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
End Class
