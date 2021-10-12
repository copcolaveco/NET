<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmbarqueCajas
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonExcel2 = New System.Windows.Forms.Button()
        Me.ButtonOcultar = New System.Windows.Forms.Button()
        Me.ButtonExcel = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frascos2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agencia2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desmarcar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frascos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargada = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(977, 532)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.ButtonExcel2)
        Me.TabPage1.Controls.Add(Me.ButtonOcultar)
        Me.TabPage1.Controls.Add(Me.ButtonExcel)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(969, 506)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cajas para embarcar"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(830, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 34)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Listar enviar por agencia"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonExcel2
        '
        Me.ButtonExcel2.Location = New System.Drawing.Point(830, 155)
        Me.ButtonExcel2.Name = "ButtonExcel2"
        Me.ButtonExcel2.Size = New System.Drawing.Size(133, 34)
        Me.ButtonExcel2.TabIndex = 4
        Me.ButtonExcel2.Text = "Imprimir enviar por agencia"
        Me.ButtonExcel2.UseVisualStyleBackColor = True
        '
        'ButtonOcultar
        '
        Me.ButtonOcultar.Location = New System.Drawing.Point(830, 6)
        Me.ButtonOcultar.Name = "ButtonOcultar"
        Me.ButtonOcultar.Size = New System.Drawing.Size(133, 34)
        Me.ButtonOcultar.TabIndex = 3
        Me.ButtonOcultar.Text = "Listar retira en Colaveco"
        Me.ButtonOcultar.UseVisualStyleBackColor = True
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Location = New System.Drawing.Point(830, 115)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(133, 34)
        Me.ButtonExcel.TabIndex = 1
        Me.ButtonExcel.Text = "Imprimir retira en Colaveco"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha2, Me.Cliente, Me.Caja, Me.Frascos, Me.Agencia, Me.Cargada})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(818, 494)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(969, 506)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cajas embarcadas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Cliente2, Me.Caja2, Me.Frascos2, Me.Agencia2, Me.Fecha, Me.Remito, Me.Desmarcar})
        Me.DataGridView2.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(953, 494)
        Me.DataGridView2.TabIndex = 1
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Width = 50
        '
        'Cliente2
        '
        Me.Cliente2.HeaderText = "Cliente"
        Me.Cliente2.Name = "Cliente2"
        Me.Cliente2.Width = 250
        '
        'Caja2
        '
        Me.Caja2.HeaderText = "Caja"
        Me.Caja2.Name = "Caja2"
        '
        'Frascos2
        '
        Me.Frascos2.HeaderText = "Frascos"
        Me.Frascos2.Name = "Frascos2"
        Me.Frascos2.Width = 60
        '
        'Agencia2
        '
        Me.Agencia2.HeaderText = "Agencia"
        Me.Agencia2.Name = "Agencia2"
        Me.Agencia2.Width = 150
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Remito
        '
        Me.Remito.HeaderText = "Remito"
        Me.Remito.Name = "Remito"
        '
        'Desmarcar
        '
        Me.Desmarcar.HeaderText = ""
        Me.Desmarcar.Name = "Desmarcar"
        Me.Desmarcar.Text = "Desmarcar"
        Me.Desmarcar.UseColumnTextForButtonValue = True
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 50
        '
        'Fecha2
        '
        Me.Fecha2.HeaderText = "Fecha"
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Width = 80
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 250
        '
        'Caja
        '
        Me.Caja.HeaderText = "Caja"
        Me.Caja.Name = "Caja"
        '
        'Frascos
        '
        Me.Frascos.HeaderText = "Frascos"
        Me.Frascos.Name = "Frascos"
        Me.Frascos.Width = 60
        '
        'Agencia
        '
        Me.Agencia.HeaderText = "Agencia"
        Me.Agencia.Name = "Agencia"
        Me.Agencia.Width = 150
        '
        'Cargada
        '
        Me.Cargada.HeaderText = ""
        Me.Cargada.Name = "Cargada"
        Me.Cargada.Text = "Cargada"
        Me.Cargada.UseColumnTextForButtonValue = True
        '
        'FormEmbarqueCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 549)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormEmbarqueCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Embarque de cajas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frascos2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desmarcar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ButtonOcultar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonExcel2 As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frascos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargada As System.Windows.Forms.DataGridViewButtonColumn
End Class
