Public Class pAislamientoATB
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAislamientoATB = CType(o, dAislamientoATB)
        Dim sql As String = "INSERT INTO aislamiento_atb (id, ficha, muestra, aislamiento, atb, resultado, aislamiento2, atb2, resultado2) VALUES (" & obj.ID & ", " & obj.FICHA & ", '" & obj.MUESTRA & "', " & obj.AISLAMIENTO & ", " & obj.ATB & ", " & obj.RESULTADO & ", " & obj.AISLAMIENTO2 & ", " & obj.ATB2 & ", " & obj.RESULTADO2 & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'aislamiento_atb', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAislamientoATB = CType(o, dAislamientoATB)
        Dim sql As String = "UPDATE aislamiento_atb SET ficha = " & obj.FICHA & ", muestra = '" & obj.MUESTRA & "', aislamiento = " & obj.AISLAMIENTO & ", atb = " & obj.ATB & ", resultado = " & obj.RESULTADO & ", aislamiento2 = " & obj.AISLAMIENTO2 & ", atb2 = " & obj.ATB2 & ", resultado2 = " & obj.RESULTADO2 & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'aislamiento_atb', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAislamientoATB = CType(o, dAislamientoATB)
        Dim sql As String = "DELETE FROM aislamiento_atb WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'aislamiento_atb', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAislamientoATB
        Dim obj As dAislamientoATB = CType(o, dAislamientoATB)
        Dim m As New dAislamientoATB
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, aislamiento, atb, resultado, aislamiento2, atb2, resultado2 FROM aislamiento_atb WHERE  id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FICHA = CType(unaFila.Item(1), Long)
                m.MUESTRA = CType(unaFila.Item(2), String)
                m.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                m.ATB = CType(unaFila.Item(4), Integer)
                m.RESULTADO = CType(unaFila.Item(5), Integer)
                m.AISLAMIENTO2 = CType(unaFila.Item(6), Integer)
                m.ATB2 = CType(unaFila.Item(7), Integer)
                m.RESULTADO2 = CType(unaFila.Item(8), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, aislamiento, atb, resultado, aislamiento2, atb2, resultado2 FROM aislamiento_atb ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dAislamientoATB
                    m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.MUESTRA = CType(unaFila.Item(2), String)
                    m.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                    m.ATB = CType(unaFila.Item(4), Integer)
                    m.RESULTADO = CType(unaFila.Item(5), Integer)
                    m.AISLAMIENTO2 = CType(unaFila.Item(6), Integer)
                    m.ATB2 = CType(unaFila.Item(7), Integer)
                    m.RESULTADO2 = CType(unaFila.Item(8), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
