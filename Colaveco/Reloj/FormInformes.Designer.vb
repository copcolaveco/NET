﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformes
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
        Me.ButtonListarTodos = New System.Windows.Forms.Button()
        Me.RadioTodos = New System.Windows.Forms.RadioButton()
        Me.RadioIndividual = New System.Windows.Forms.RadioButton()
        Me.ComboUsuarios = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(23, 87)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(101, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(143, 87)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(101, 20)
        Me.DateHasta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(140, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'ButtonListarTodos
        '
        Me.ButtonListarTodos.Location = New System.Drawing.Point(46, 123)
        Me.ButtonListarTodos.Name = "ButtonListarTodos"
        Me.ButtonListarTodos.Size = New System.Drawing.Size(198, 23)
        Me.ButtonListarTodos.TabIndex = 6
        Me.ButtonListarTodos.Text = "Listar informe"
        Me.ButtonListarTodos.UseVisualStyleBackColor = True
        '
        'RadioTodos
        '
        Me.RadioTodos.AutoSize = True
        Me.RadioTodos.Location = New System.Drawing.Point(12, 12)
        Me.RadioTodos.Name = "RadioTodos"
        Me.RadioTodos.Size = New System.Drawing.Size(55, 17)
        Me.RadioTodos.TabIndex = 7
        Me.RadioTodos.TabStop = True
        Me.RadioTodos.Text = "Todos"
        Me.RadioTodos.UseVisualStyleBackColor = True
        '
        'RadioIndividual
        '
        Me.RadioIndividual.AutoSize = True
        Me.RadioIndividual.Location = New System.Drawing.Point(12, 35)
        Me.RadioIndividual.Name = "RadioIndividual"
        Me.RadioIndividual.Size = New System.Drawing.Size(70, 17)
        Me.RadioIndividual.TabIndex = 8
        Me.RadioIndividual.TabStop = True
        Me.RadioIndividual.Text = "Individual"
        Me.RadioIndividual.UseVisualStyleBackColor = True
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.FormattingEnabled = True
        Me.ComboUsuarios.Location = New System.Drawing.Point(88, 35)
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(239, 21)
        Me.ComboUsuarios.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(46, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Listar marcas desde la base de datos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 190)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboUsuarios)
        Me.Controls.Add(Me.RadioIndividual)
        Me.Controls.Add(Me.RadioTodos)
        Me.Controls.Add(Me.ButtonListarTodos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonListarTodos As System.Windows.Forms.Button
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
    Friend WithEvents RadioIndividual As System.Windows.Forms.RadioButton
    Friend WithEvents ComboUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
