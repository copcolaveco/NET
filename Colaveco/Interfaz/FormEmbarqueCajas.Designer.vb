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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonExcel2 = New System.Windows.Forms.Button()
        Me.ButtonOcultar = New System.Windows.Forms.Button()
        Me.ButtonExcel = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frascos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesmarcarEmbarque = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Embarcar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PedidoAgencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frascos2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agencia2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desembarcar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.AntiqueWhite
        Me.TabPage2.Controls.Add(Me.btnBuscar)
        Me.TabPage2.Controls.Add(Me.dtHasta)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.dtDesde)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1455, 626)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cajas EMBARCADAS"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(71, 553)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(115, 23)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtHasta
        '
        Me.dtHasta.Location = New System.Drawing.Point(21, 492)
        Me.dtHasta.Name = "dtHasta"
        Me.dtHasta.Size = New System.Drawing.Size(200, 22)
        Me.dtHasta.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 472)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasta"
        '
        'dtDesde
        '
        Me.dtDesde.Location = New System.Drawing.Point(21, 436)
        Me.dtDesde.Name = "dtDesde"
        Me.dtDesde.Size = New System.Drawing.Size(200, 22)
        Me.dtDesde.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 416)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.PedidoAgencia, Me.Cliente2, Me.Caja2, Me.Frascos2, Me.Agencia2, Me.Fecha, Me.Remito, Me.Desembarcar})
        Me.DataGridView2.Location = New System.Drawing.Point(8, 12)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1430, 400)
        Me.DataGridView2.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.ButtonExcel2)
        Me.TabPage1.Controls.Add(Me.ButtonOcultar)
        Me.TabPage1.Controls.Add(Me.ButtonExcel)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1455, 626)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cajas PREPARADAS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(32, 538)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(177, 48)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Listar enviar por agencia"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonExcel2
        '
        Me.ButtonExcel2.Location = New System.Drawing.Point(284, 537)
        Me.ButtonExcel2.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonExcel2.Name = "ButtonExcel2"
        Me.ButtonExcel2.Size = New System.Drawing.Size(177, 48)
        Me.ButtonExcel2.TabIndex = 4
        Me.ButtonExcel2.Text = "Imprimir enviar por agencia"
        Me.ButtonExcel2.UseVisualStyleBackColor = True
        '
        'ButtonOcultar
        '
        Me.ButtonOcultar.Location = New System.Drawing.Point(32, 488)
        Me.ButtonOcultar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonOcultar.Name = "ButtonOcultar"
        Me.ButtonOcultar.Size = New System.Drawing.Size(177, 48)
        Me.ButtonOcultar.TabIndex = 3
        Me.ButtonOcultar.Text = "Listar retira en Colaveco"
        Me.ButtonOcultar.UseVisualStyleBackColor = True
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Location = New System.Drawing.Point(284, 488)
        Me.ButtonExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(177, 48)
        Me.ButtonExcel.TabIndex = 1
        Me.ButtonExcel.Text = "Imprimir retira en Colaveco"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Pedido, Me.Fecha2, Me.Cliente, Me.Caja, Me.Frascos, Me.Agencia, Me.DesmarcarEmbarque, Me.Embarcar})
        Me.DataGridView1.Location = New System.Drawing.Point(8, 7)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1439, 461)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 50
        '
        'Pedido
        '
        Me.Pedido.HeaderText = "idPedido"
        Me.Pedido.Name = "Pedido"
        Me.Pedido.ReadOnly = True
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
        'DesmarcarEmbarque
        '
        Me.DesmarcarEmbarque.HeaderText = ""
        Me.DesmarcarEmbarque.Name = "DesmarcarEmbarque"
        Me.DesmarcarEmbarque.Text = "Mod Pedido"
        Me.DesmarcarEmbarque.UseColumnTextForButtonValue = True
        '
        'Embarcar
        '
        Me.Embarcar.HeaderText = ""
        Me.Embarcar.Name = "Embarcar"
        Me.Embarcar.Text = "Embarcar"
        Me.Embarcar.UseColumnTextForButtonValue = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 15)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1463, 655)
        Me.TabControl1.TabIndex = 0
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Width = 50
        '
        'PedidoAgencia
        '
        Me.PedidoAgencia.HeaderText = "idPedidoAgencia"
        Me.PedidoAgencia.Name = "PedidoAgencia"
        Me.PedidoAgencia.ReadOnly = True
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
        'Desembarcar
        '
        Me.Desembarcar.HeaderText = ""
        Me.Desembarcar.Name = "Desembarcar"
        Me.Desembarcar.Text = "Desembarcar"
        Me.Desembarcar.UseColumnTextForButtonValue = True
        '
        'FormEmbarqueCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1482, 676)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormEmbarqueCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Embarque de cajas"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cargada As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonExcel2 As System.Windows.Forms.Button
    Friend WithEvents ButtonOcultar As System.Windows.Forms.Button
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frascos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesmarcarEmbarque As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Embarcar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PedidoAgencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frascos2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desembarcar As System.Windows.Forms.DataGridViewButtonColumn
End Class
