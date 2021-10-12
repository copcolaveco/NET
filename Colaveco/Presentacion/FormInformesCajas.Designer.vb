<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformesCajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformesCajas))
        Me.ListInformes = New System.Windows.Forms.ListBox
        Me.ButtonSinDevolver = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Listproductor = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonListarxcaja = New System.Windows.Forms.Button
        Me.ButtonImprimirxfecha = New System.Windows.Forms.Button
        Me.ButtonImprimirxcaja = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ButtonListarxCliente = New System.Windows.Forms.Button
        Me.ButtonImprimirxcliente = New System.Windows.Forms.Button
        Me.TextIdCliente = New System.Windows.Forms.TextBox
        Me.ButtonBuscarCliente = New System.Windows.Forms.Button
        Me.TextCliente = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ListInformes
        '
        Me.ListInformes.FormattingEnabled = True
        Me.ListInformes.Location = New System.Drawing.Point(134, 68)
        Me.ListInformes.Name = "ListInformes"
        Me.ListInformes.Size = New System.Drawing.Size(298, 420)
        Me.ListInformes.TabIndex = 0
        '
        'ButtonSinDevolver
        '
        Me.ButtonSinDevolver.Location = New System.Drawing.Point(10, 68)
        Me.ButtonSinDevolver.Name = "ButtonSinDevolver"
        Me.ButtonSinDevolver.Size = New System.Drawing.Size(118, 23)
        Me.ButtonSinDevolver.TabIndex = 1
        Me.ButtonSinDevolver.Text = "Listar x fecha"
        Me.ButtonSinDevolver.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(165, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Grad.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Grad.2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Productor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Caja"
        '
        'Listproductor
        '
        Me.Listproductor.FormattingEnabled = True
        Me.Listproductor.Location = New System.Drawing.Point(438, 68)
        Me.Listproductor.Name = "Listproductor"
        Me.Listproductor.Size = New System.Drawing.Size(483, 420)
        Me.Listproductor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(273, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Grad.3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(435, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Fecha envío"
        '
        'ButtonListarxcaja
        '
        Me.ButtonListarxcaja.Location = New System.Drawing.Point(10, 97)
        Me.ButtonListarxcaja.Name = "ButtonListarxcaja"
        Me.ButtonListarxcaja.Size = New System.Drawing.Size(118, 23)
        Me.ButtonListarxcaja.TabIndex = 10
        Me.ButtonListarxcaja.Text = "Listar x Nº Caja"
        Me.ButtonListarxcaja.UseVisualStyleBackColor = True
        '
        'ButtonImprimirxfecha
        '
        Me.ButtonImprimirxfecha.Location = New System.Drawing.Point(10, 155)
        Me.ButtonImprimirxfecha.Name = "ButtonImprimirxfecha"
        Me.ButtonImprimirxfecha.Size = New System.Drawing.Size(116, 23)
        Me.ButtonImprimirxfecha.TabIndex = 11
        Me.ButtonImprimirxfecha.Text = "Imprimir x fecha"
        Me.ButtonImprimirxfecha.UseVisualStyleBackColor = True
        '
        'ButtonImprimirxcaja
        '
        Me.ButtonImprimirxcaja.Location = New System.Drawing.Point(10, 184)
        Me.ButtonImprimirxcaja.Name = "ButtonImprimirxcaja"
        Me.ButtonImprimirxcaja.Size = New System.Drawing.Size(116, 23)
        Me.ButtonImprimirxcaja.TabIndex = 12
        Me.ButtonImprimirxcaja.Text = "Imprimir x Nº Caja"
        Me.ButtonImprimirxcaja.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(328, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Frascos."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(134, 494)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(787, 23)
        Me.ProgressBar1.TabIndex = 14
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(10, 21)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(89, 20)
        Me.DateDesde.TabIndex = 15
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(105, 21)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(89, 20)
        Me.DateHasta.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Desde"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(105, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Hasta"
        '
        'ButtonListarxCliente
        '
        Me.ButtonListarxCliente.Location = New System.Drawing.Point(12, 126)
        Me.ButtonListarxCliente.Name = "ButtonListarxCliente"
        Me.ButtonListarxCliente.Size = New System.Drawing.Size(116, 23)
        Me.ButtonListarxCliente.TabIndex = 19
        Me.ButtonListarxCliente.Text = "Listar x cliente"
        Me.ButtonListarxCliente.UseVisualStyleBackColor = True
        '
        'ButtonImprimirxcliente
        '
        Me.ButtonImprimirxcliente.Location = New System.Drawing.Point(10, 213)
        Me.ButtonImprimirxcliente.Name = "ButtonImprimirxcliente"
        Me.ButtonImprimirxcliente.Size = New System.Drawing.Size(116, 23)
        Me.ButtonImprimirxcliente.TabIndex = 20
        Me.ButtonImprimirxcliente.Text = "Imprimir x cliente"
        Me.ButtonImprimirxcliente.UseVisualStyleBackColor = True
        '
        'TextIdCliente
        '
        Me.TextIdCliente.Location = New System.Drawing.Point(617, 21)
        Me.TextIdCliente.Name = "TextIdCliente"
        Me.TextIdCliente.Size = New System.Drawing.Size(47, 20)
        Me.TextIdCliente.TabIndex = 21
        Me.TextIdCliente.Visible = False
        '
        'ButtonBuscarCliente
        '
        Me.ButtonBuscarCliente.Location = New System.Drawing.Point(210, 19)
        Me.ButtonBuscarCliente.Name = "ButtonBuscarCliente"
        Me.ButtonBuscarCliente.Size = New System.Drawing.Size(132, 22)
        Me.ButtonBuscarCliente.TabIndex = 22
        Me.ButtonBuscarCliente.Text = "Seleccionar cliente"
        Me.ButtonBuscarCliente.UseVisualStyleBackColor = True
        '
        'TextCliente
        '
        Me.TextCliente.Location = New System.Drawing.Point(348, 21)
        Me.TextCliente.Name = "TextCliente"
        Me.TextCliente.Size = New System.Drawing.Size(263, 20)
        Me.TextCliente.TabIndex = 23
        '
        'FormInformesCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 529)
        Me.Controls.Add(Me.TextCliente)
        Me.Controls.Add(Me.ButtonBuscarCliente)
        Me.Controls.Add(Me.TextIdCliente)
        Me.Controls.Add(Me.ButtonImprimirxcliente)
        Me.Controls.Add(Me.ButtonListarxCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ButtonImprimirxcaja)
        Me.Controls.Add(Me.ButtonImprimirxfecha)
        Me.Controls.Add(Me.ButtonListarxcaja)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Listproductor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonSinDevolver)
        Me.Controls.Add(Me.ListInformes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInformesCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de cajas sin devolver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListInformes As System.Windows.Forms.ListBox
    Friend WithEvents ButtonSinDevolver As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Listproductor As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonListarxcaja As System.Windows.Forms.Button
    Friend WithEvents ButtonImprimirxfecha As System.Windows.Forms.Button
    Friend WithEvents ButtonImprimirxcaja As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonListarxCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonImprimirxcliente As System.Windows.Forms.Button
    Friend WithEvents TextIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents TextCliente As System.Windows.Forms.TextBox
End Class
