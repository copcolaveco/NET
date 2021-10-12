Public Class pActasItem
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItem = CType(o, dActasItem)
        Dim sql As String = "INSERT INTO actas_item (id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado) VALUES (" & obj.ID & ", " & obj.IDACTA & ", '" & obj.TEMA & "', '" & obj.RESUMEN & "', '" & obj.RESPONSABLES & "'," & obj.TITULAR & "," & obj.TITULAR2 & ", '" & obj.PLAZO & "'," & obj.EFECTUADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItem = CType(o, dActasItem)
        Dim sql As String = "UPDATE actas_item SET idacta =" & obj.IDACTA & ", tema= '" & obj.TEMA & "',resumen= '" & obj.RESUMEN & "', responsables='" & obj.RESPONSABLES & "',titular=" & obj.TITULAR & ",titular2=" & obj.TITULAR2 & ", plazo= '" & obj.PLAZO & "', efectuado= " & obj.EFECTUADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarefectuada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItem = CType(o, dActasItem)
        Dim sql As String = "UPDATE actas_item SET efectuado= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item', 'marcar_efectuada', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItem = CType(o, dActasItem)
        Dim sql As String = "DELETE FROM actas_item WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dActasItem
        Dim obj As dActasItem = CType(o, dActasItem)
        Dim p As New dActasItem
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.IDACTA = CType(unaFila.Item(1), Long)
                p.TEMA = CType(unaFila.Item(2), String)
                p.RESUMEN = CType(unaFila.Item(3), String)
                p.RESPONSABLES = CType(unaFila.Item(4), String)
                p.TITULAR = CType(unaFila.Item(5), Integer)
                p.TITULAR2 = CType(unaFila.Item(6), Integer)
                p.PLAZO = CType(unaFila.Item(7), String)
                p.EFECTUADO = CType(unaFila.Item(8), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item ORDER BY plazo ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listarxidacta(ByVal idacta As Long) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE idacta = " & idacta & " ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpendientes() As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE efectuado = 0 ORDER BY plazo ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarefectuados() As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE efectuado = 1 ORDER BY plazo DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarefectuadosxgrupo(ByVal idacta As Long) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE idacta = " & idacta & " AND efectuado = 1 ORDER BY plazo DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartodosxgrupo(ByVal idacta As Long) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE idacta = " & idacta & " ORDER BY plazo DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpendientesxgrupo(ByVal idacta As Long) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE idacta = " & idacta & " AND efectuado = 0 ORDER BY plazo DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarvencidosxgrupo(ByVal idacta As Long, ByVal fec As String) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE idacta = " & idacta & " AND efectuado = 0 AND plazo <= '" & fec & "' ORDER BY plazo DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarvencidos(ByVal fecha As String) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE efectuado = 0 AND plazo <= '" & fecha & "' ORDER BY plazo ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxtitular(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, idacta, tema, resumen, responsables, titular, titular2, plazo, efectuado FROM actas_item WHERE efectuado = 0 AND titular = " & idusuario & " OR titular2= " & idusuario & " "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItem
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.TEMA = CType(unaFila.Item(2), String)
                    p.RESUMEN = CType(unaFila.Item(3), String)
                    p.RESPONSABLES = CType(unaFila.Item(4), String)
                    p.TITULAR = CType(unaFila.Item(5), Integer)
                    p.TITULAR2 = CType(unaFila.Item(6), Integer)
                    p.PLAZO = CType(unaFila.Item(7), String)
                    p.EFECTUADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
