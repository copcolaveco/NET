<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMuestrasNoAptas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMuestrasNoAptas))
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.ComboMotivo = New System.Windows.Forms.ComboBox
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.ListMuestras = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Enabled = False
        Me.TextFicha.Location = New System.Drawing.Point(12, 25)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(66, 20)
        Me.TextFicha.TabIndex = 0
        '
        'ComboMotivo
        '
        Me.ComboMotivo.FormattingEnabled = True
        Me.ComboMotivo.Location = New System.Drawing.Point(11, 64)
        Me.ComboMotivo.MaxDropDownItems = 10
        Me.ComboMotivo.Name = "ComboMotivo"
        Me.ComboMotivo.Size = New System.Drawing.Size(170, 21)
        Me.ComboMotivo.TabIndex = 1
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(187, 65)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(46, 20)
        Me.TextCantidad.TabIndex = 2
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Location = New System.Drawing.Point(239, 64)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(76, 21)
        Me.ButtonAgregar.TabIndex = 3
        Me.ButtonAgregar.Text = "Agregar"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'ListMuestras
        '
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(12, 91)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(221, 121)
        Me.ListMuestras.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Motivo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cantidad"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(240, 91)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 21)
        Me.ButtonEliminar.TabIndex = 8
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(253, 41)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(47, 20)
        Me.TextId.TabIndex = 9
        Me.TextId.Visible = False
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(240, 118)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 20)
        Me.ButtonNuevo.TabIndex = 10
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'FormMuestrasNoAptas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 222)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListMuestras)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.ComboMotivo)
        Me.Controls.Add(Me.TextFicha)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMuestrasNoAptas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Muestras no aptas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ComboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
End Class
